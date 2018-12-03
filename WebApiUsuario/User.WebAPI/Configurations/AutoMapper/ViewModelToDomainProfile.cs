using AutoMapper;
using User.Domain.User.Model;
using User.WebAPI.ViewAndInputModel;

namespace WebApi.Configurations.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<UsersViewModel, Users>()
                 .ForMember(f => f.Name, t => t.MapFrom(m => m.Name))
                 .ForMember(f => f.DocumentNumber, t => t.MapFrom(m => m.DocumentNumber))
                 .ForMember(f => f.Age, t => t.MapFrom(m => m.Age));
        }
    }
}
