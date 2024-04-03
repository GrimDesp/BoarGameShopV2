
namespace BoardGameShop.DAL.Repositories
{
    public class BoardGameRepository : BaseRepository<BoardGame>, IBoardGameRepository
    {
        public BoardGameRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        public async Task<int> CountPages(int itemPerPage)
        {
            int item = await Table.CountAsync();
            return (int)Math.Ceiling((double)(item / itemPerPage));
        }
    }
}
