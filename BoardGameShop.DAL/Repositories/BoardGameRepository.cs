namespace BoardGameShop.DAL.Repositories
{
    public class BoardGameRepository : BaseRepository<BoardGame>, IBoardGameRepository
    {
        public BoardGameRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
    }
}
