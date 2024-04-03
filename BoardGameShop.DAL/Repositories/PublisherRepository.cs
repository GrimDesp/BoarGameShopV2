
namespace BoardGameShop.DAL.Repositories
{
    public class PublisherRepository : BaseRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
