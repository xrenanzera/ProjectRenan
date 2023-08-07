using AutoMapper;
using Moq;
using ProjectRenan.Application.AutoMapper;
using ProjectRenan.Application.Services;
using ProjectRenan.Application.ViewModels;
using ProjectRenan.Domain.Entities;
using ProjectRenan.Domain.Interfaces;
using Xunit;

namespace ProjectRenan.Application.Tests.Services
{
    public class UserServiceTests
    {
        private UserService userService;
        public UserServiceTests()
        {
            userService = new UserService(new Mock<IUserRepository>().Object, new Mock<IMapper>().Object);
        }

        [Fact]
        public void Post_SendingValidId()
        {
            var exception = Assert.Throws<Exception>(() => userService.Post(new UserViewModel { Id = Guid.NewGuid() }));
            Assert.Equal("UserID must be empty", exception.Message);
        }

        [Fact]
        public void GetById_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => userService.GetById(""));
            Assert.Equal("UserID is not valid", exception.Message);
        }

        [Fact]
        public void Put_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => userService.Put(new UserViewModel()));
            Assert.Equal("ID is invalid", exception.Message);
        }

        [Fact]
        public void Delete_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => userService.Delete(""));
            Assert.Equal("UserID is not valid", exception.Message);
        }

        [Fact]
        public void Authenticate_SendingEmptyValues()
        {
            var exception = Assert.Throws<Exception>(() => userService.Authenticate(new UserAuthenticateRequestViewModel()));
            Assert.Equal("Email/Password are required", exception.Message);
        }

        [Fact]
        public void Post_SendingValidObject()
        {
            var result = userService.Post(new UserViewModel { Name = "Renan Nogueira", Email = "renan.nogueira@outlook.com" });
            Assert.True(result);
        }

        [Fact]
        public void Get_ValidatingObject()
        {
            List<User> _users = new()
            {
                new User {
                    Id = Guid.NewGuid(),
                    Name = "Renan Nogueira",
                    Email = "renan.nogueira@outlook.com",
                    DateCreated = DateTime.Now
                }
            };

            var _userRepository = new Mock<IUserRepository>();
            _userRepository.Setup(x => x.GetAll()).Returns(_users);

            var _autoMapperProfile = new AutoMapperSetup();
            var _configuration = new MapperConfiguration(x => x.AddProfile(_autoMapperProfile));

            IMapper _mapper = new Mapper(_configuration);

            userService = new UserService(_userRepository.Object, _mapper);

            var result = userService.Get();
            Assert.True(result.Count > 0);
        }
    }
}
