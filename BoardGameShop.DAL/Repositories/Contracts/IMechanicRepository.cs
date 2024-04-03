namespace BoardGameShop.DAL.Repositories.Contracts
{
    public interface IMechanicRepository : IBaseRepo<Mechanic>
    {
        Task<IEnumerable<Mechanic>> GetAll();
    }
}
