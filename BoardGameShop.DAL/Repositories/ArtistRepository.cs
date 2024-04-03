
namespace BoardGameShop.DAL.Repositories
{
    public class ArtistRepository : BaseRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
