namespace BoardGameShop.DAL.Repositories.Contracts
{
    public interface IUserRepository : IBaseRepo<User>
    {
        IQueryable<User> GetUser(int id);
        IQueryable<User> GetUserByUsername(string username);
        IQueryable<User> GetUserQueryable();
    }
}
