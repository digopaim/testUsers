using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Domain.User.Model;
using User.Domain.User.Repository;
using User.WebAPI.ViewAndInputModel;
using WebApi.Controllers;

namespace User.WebAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class UsersController : ApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("GetUsers")]
        [ProducesResponseType((int)System.Net.HttpStatusCode.OK)]
        public IActionResult Get()
        {
            var listViewModel = _userRepository.GetAll().ProjectTo<UsersViewModel>();
            return Response(listViewModel);
        }
        [HttpPost("DeleteUser")]
        public IActionResult Delete([FromBody] int id)
        {
           _userRepository.Remove(id);
            return Response();
        }
        [HttpPost("AddUser")]
        public IActionResult Add([FromBody] UsersViewModel user)
        {
            var newuser = _mapper.Map<Users>(user);
            _userRepository.Add(newuser);
            return Response();
        }
        [HttpPost("UpdateUser")]
        public IActionResult Update([FromBody] UsersViewModel user)
        {
            var updateuser = _mapper.Map<Users>(user);
            _userRepository.Update(updateuser);
            return Response();
        }
    }
}