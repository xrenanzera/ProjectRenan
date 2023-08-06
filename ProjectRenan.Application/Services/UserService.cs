using AutoMapper;
using ProjectRenan.Application.Interfaces;
using ProjectRenan.Application.ViewModels;
using ProjectRenan.Domain.Entities;
using ProjectRenan.Domain.Interfaces;

namespace ProjectRenan.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public List<UserViewModel> Get()
        {
         
            IEnumerable<User> _users = this.userRepository.GetAll();
            List<UserViewModel> _userViewModels = mapper.Map<List<UserViewModel>>(_users);

            foreach (User item in _users)
                _userViewModels.Add(new UserViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email
                });

            return _userViewModels;
        }

        public bool Post(UserViewModel userViewModel)
        {
            User _user = mapper.Map<User>(userViewModel);
            this.userRepository.Create(_user);
            return true;
        }
    }
}
