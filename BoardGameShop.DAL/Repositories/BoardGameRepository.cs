using Microsoft.Identity.Client;

namespace BoardGameShop.DAL.Repositories
{
    public class BoardGameRepository : BaseRepository<Boardgame>, IBoardGameRepository
    {
        public BoardGameRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        public async Task<int> CountPages(int itemPerPage)
        {
            int item = await Table.CountAsync();
            return (int)Math.Ceiling((double)(item / itemPerPage));
        }

        public async Task<(IEnumerable<Boardgame>, int)> GetByFilter(RequestFilterDto filterDto)
        {
            int totalItems = 0;
            var request = Table.AsQueryable();

            request = FilterByPublishers(request, filterDto.PublisherIds);
            request = FilterByCategories(request, filterDto.CategoryIds);
            request = FilterByMechanics(request, filterDto.MechanicIds);
            request = FilterByAuthors(request, filterDto.AuthorsIds);
            request = FilterByArtist(request, filterDto.ArtistIds);
            (request, totalItems) = await CountTotalPage(request);
            request = request.OrderBy(x => x.Name);
            request = Pagination(request, filterDto.CurrentPage, filterDto.ItemsPerPage);
            request = request.Select(cd => new Boardgame
            {
                Age = cd.Age,
                Discount = cd.Discount,
                FullPrice = cd.FullPrice,
                Id = cd.Id,
                MaxPlayer = cd.MaxPlayer,
                MinPlayer = cd.MinPlayer,
                MaxPlayTime = cd.MaxPlayTime,
                MinPlayTime = cd.MinPlayTime,
                Name = cd.Name,
                Quantity = cd.Quantity
            });
            return (request.ToList(), (int)Math.Ceiling(((double)totalItems / filterDto.ItemsPerPage)));
        }
        private IQueryable<Boardgame> Pagination(IQueryable<Boardgame> games, int currentPage, int itemPerPage)
        {
            return games.Skip(currentPage * itemPerPage).Take(itemPerPage);
        }
        private IQueryable<Boardgame> FilterByCategories(IQueryable<Boardgame> games, IEnumerable<int> categoriesIds)
        {
            if (categoriesIds.Count() == 0 || categoriesIds == null) return games;
            return games.Include(x => x.BoardgameCategories)
                .Where(g => g.BoardgameCategories.Where(bg => categoriesIds.Contains(bg.CategoryId)).Any());
        }
        private IQueryable<Boardgame> FilterByMechanics(IQueryable<Boardgame> games, IEnumerable<int> mechanicIds)
        {
            if (mechanicIds.Count() == 0 || mechanicIds == null) return games;
            return games.Include(g => g.BoardgameMechanics)
                .Where(g => g.BoardgameMechanics.Where(bm => mechanicIds.Contains(bm.MechanicId)).Any());
        }
        private IQueryable<Boardgame> FilterByAuthors(IQueryable<Boardgame> boardgames, IEnumerable<int> authorIds)
        {
            if (authorIds.Count() == 0 || authorIds == null) return boardgames;
            return boardgames.Include(g => g.BoardgameAuthors)
                .Where(g => g.BoardgameAuthors.Where(ga => authorIds.Contains(ga.AuthorId)).Any());
        }
        private IQueryable<Boardgame> FilterByArtist(IQueryable<Boardgame> boardgames, IEnumerable<int> artistIds)
        {
            if (artistIds.Count() == 0 || artistIds == null) return boardgames;
            return boardgames.Include(g => g.BoardgameArtists)
                .Where(g => g.BoardgameArtists.Where(gar => artistIds.Contains(gar.ArtistId)).Any());
        }
        private IQueryable<Boardgame> FilterByPublishers(IQueryable<Boardgame> boardgames, IEnumerable<int> publisherIds)
        {
            if (publisherIds.Count() == 0 || publisherIds == null) return boardgames;
            return boardgames.Where(g => publisherIds.Contains(g.PublisherId));
        }
        private async Task<(IQueryable<Boardgame>, int)> CountTotalPage(IQueryable<Boardgame> boardgames)
        {
            int totalPage = await boardgames.CountAsync();
            return (boardgames, totalPage);
        }

        public async Task<Boardgame> GetById(int id)
        {
            var game = await Table.Include(cd => cd.PublisherNavigation)
                .Include(cd => cd.VendorNavigation)
                .Include(cd => cd.Mechanics)
                .Include(cd => cd.Categories)
                .Include(cd => cd.Artists)
                .Include(cd => cd.Authors)
                .FirstAsync(g => g.Id == id);
            return game ?? new Boardgame();
        }
    }
}
