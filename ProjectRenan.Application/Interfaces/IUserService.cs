using ProjectRenan.Application.ViewModels;

namespace ProjectRenan.Application.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> Get();
    }
}
