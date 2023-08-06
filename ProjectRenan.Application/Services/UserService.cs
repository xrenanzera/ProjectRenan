using AutoMapper;
using ProjectRenan.Application.Interfaces;
using ProjectRenan.Application.ViewModels;
using ProjectRenan.Domain.Entities;
using ProjectRenan.Domain.Interfaces;
using System.Net;

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

        public UserViewModel GetById(string id) 
        {
            if (!Guid.TryParse(id, out var userId))
                throw new Exception("UserID is not valid");

            User _user = userRepository.GetById(userId) ??
                                    throw new Exception("UserID not found");

            return mapper.Map<UserViewModel>(_user);
        }

        public bool Put(UserViewModel userViewModel)
        {
            User _user = userRepository.GetById(userViewModel.Id) ??
                                 throw new Exception("UserID not found");

            _user = mapper.Map<User>(userViewModel);

          return this.userRepository.Update(_user);
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out var userId))
                throw new Exception("UserID is not valid");

            User _user = userRepository.GetById(userId) ??
                               throw new Exception("UserID not found");

            return this.userRepository.Delete(_user);

        }
    }
}
