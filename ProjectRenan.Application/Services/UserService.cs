using ProjectRenan.Application.Interfaces;
using ProjectRenan.Application.ViewModels;
using ProjectRenan.Domain.Entities;
using ProjectRenan.Domain.Interfaces;

namespace ProjectRenan.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<UserViewModel> Get()
        {
            List<UserViewModel> userViewModels = new();
            IEnumerable<User> _users = this.userRepository.GetAll();

            foreach (User item in _users)
                userViewModels.Add(new UserViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email
                });

            return userViewModels;
        }

        public bool Post(UserViewModel userViewModel)
        {
            User _user = new()
            {
                Name = userViewModel.Name,
                Email = userViewModel.Email,
            };

            this.userRepository.Create(_user);
            return true;
        }
    }
}
