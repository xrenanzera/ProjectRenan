using ProjectRenan.Domain.Entities;

namespace ProjectRenan.Domain.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
    }
}
