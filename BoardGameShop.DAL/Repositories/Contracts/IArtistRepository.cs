namespace BoardGameShop.DAL.Repositories.Contracts
{
    public interface IArtistRepository : IBaseRepo<Artist>
    {
        Task<IEnumerable<Artist>> GetAll();
    }
}
