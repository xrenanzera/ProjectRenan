using ProjectRenan.Domain.Entities;

namespace ProjectRenan.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAll();
        User GetById(Guid userId);
    }
}
