using AutoMapper;
using ProjectRenan.Application.ViewModels;
using ProjectRenan.Domain.Entities;

namespace ProjectRenan.Application.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModel to Domain
            CreateMap<UserViewModel, User>();
            #endregion

            #region Domain to ViewModel
            CreateMap<User, UserViewModel>();
            #endregion
        }
    }
}
