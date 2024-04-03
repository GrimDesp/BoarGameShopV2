
namespace BoardGameShop.DAL.Repositories
{
    public class MechanicRepository : BaseRepository<Mechanic>, IMechanicRepository
    {
        public MechanicRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
