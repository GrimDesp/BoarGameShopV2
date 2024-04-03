namespace BoardGameShop.DAL.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
