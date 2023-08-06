using ProjectRenan.Application.ViewModels;

namespace ProjectRenan.Application.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> Get();
        bool Post(UserViewModel model);
        UserViewModel GetById(string id);
        bool Put(UserViewModel userViewModel);
        bool Delete(string id);
    }
}
