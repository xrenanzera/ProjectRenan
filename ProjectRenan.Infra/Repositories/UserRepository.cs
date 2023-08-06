using ProjectRenan.Data.Context;
using ProjectRenan.Domain.Entities;
using ProjectRenan.Domain.Interfaces;

namespace ProjectRenan.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ProjectRenanContext context) : base(context)
        {
        }

        public IEnumerable<User> GetAll()
        {
           return Query(x => !x.IsDeleted == false);
        }
    }
}
