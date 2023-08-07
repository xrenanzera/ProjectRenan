using AutoMapper;
using ProjectRenan.Application.Interfaces;
using ProjectRenan.Application.ViewModels;
using ProjectRenan.Auth.Services;
using ProjectRenan.Domain.Entities;
using ProjectRenan.Domain.Interfaces;
using System.Security.Cryptography;
using System.Text;

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

            return _userViewModels;
        }

        public bool Post(UserViewModel userViewModel)
        {
            if (userViewModel.Id != Guid.Empty)
                throw new Exception("UserID must be empty");

            User _user = mapper.Map<User>(userViewModel);
            _user.Password = EncryptPassword(_user.Password);

            this.userRepository.Create(_user);
            return true;
        }

        public UserViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out var userId))
                throw new Exception("UserID is not valid");

            User _user = userRepository.Find(userId) ??
                                    throw new Exception("UserID not found");

            return mapper.Map<UserViewModel>(_user);
        }

        public bool Put(UserViewModel userViewModel)
        {
            if (userViewModel.Id == Guid.Empty)
                throw new Exception("ID is invalid");

            User _user = userRepository.Find(userViewModel.Id) ??
                                 throw new Exception("UserID not found");

            _user = mapper.Map<User>(userViewModel);
            _user.Password = EncryptPassword(_user.Password);

            return this.userRepository.Update(_user);
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out var userId))
                throw new Exception("UserID is not valid");

            User _user = userRepository.Find(userId) ??
                               throw new Exception("UserID not found");

            return this.userRepository.Delete(_user);
        }

        public UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
                throw new Exception("Email/Password are required");

            user.Password = EncryptPassword(user.Password);

            User _user = this.userRepository.Find(x => !x.IsDeleted &&
                            x.Email.ToLower() == user.Email.ToLower() &&
                          x.Password.ToLower() == user.Password.ToLower());

            if (_user == null)
                throw new Exception("User Not found");

            return new UserAuthenticateResponseViewModel(mapper.Map<UserViewModel>(_user), TokenService.GenerateToken(_user));
        }

        private static string EncryptPassword(string strData)
        {
            var message = Encoding.UTF8.GetBytes(strData);
            using var alg = SHA512.Create();
            string hex = "";

            var hashValue = alg.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }


    }
}
