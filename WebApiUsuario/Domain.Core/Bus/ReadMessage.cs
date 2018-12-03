using AutoMapper;
using Newtonsoft.Json;
using Domain.Core.Commands;
using Domain.Core.Mediator;
using RabbitMQ;
using RabbitMQ.Interfaces;
using RabbitMQ.TypesFind;
using System;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Errors;

namespace Domain.Core.Bus
{
    public class ReadMessage : IReadMessage
    {
        private readonly IMediatorHandler Mediator;
        private readonly IMapper _mapper;

        public ReadMessage(IMediatorHandler mediator, IMapper mapper)
        {
            Mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Read the command of SagaManager
        /// </summary>
        /// <param name="message"></param>
        public void Read(MessageTransfer message)
        {
            //Get the command of SagaManager
            var typeOfCommand = message.Type.FindCommand().FirstOrDefault();
            if (typeOfCommand != null)
            {
                Console.WriteLine($"Read Command Message ({DateTime.Now}): { message.Type } Time Stamp: {message.CreatedOn}");
                var commad = (Command)JsonConvert.DeserializeObject(message.DataJson, typeOfCommand);
                Console.WriteLine($"Send  Command Message ({DateTime.Now}): { commad.MessageType }");
                Task commandSend = Mediator.SendCommand(Guid.NewGuid(), commad);
                if (!commandSend.IsCompletedSuccessfully)
                    throw new ArgumentException("Command not completed");
            }
            else
            {
                Console.WriteLine("Command not found on Domain: " + message.Type);
                throw new CommandNotFoundException("Command not found on Domain");
            }

        }

    }

}
