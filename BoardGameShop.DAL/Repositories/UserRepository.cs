

namespace BoardGameShop.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        public IQueryable<User> GetUser(int id)
        {
            return Table.AsQueryable().Where(u => u.Id == id);
        }

        public IQueryable<User> GetUserByUsername(string username)
            => GetUserQueryable().Where(u => u.Username == username);


        public IQueryable<User> GetUserQueryable()
            => Table.AsQueryable();
    }
}
