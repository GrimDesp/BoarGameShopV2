using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataFilterController : ControllerBase
    {
        private readonly IMechanicRepository mechanicsRepo;
        private readonly ICategoryRepository categoriesRepo;
        private readonly IAuthorRepository authorsRepo;
        private readonly IArtistRepository artistsRepo;
        private readonly IPublisherRepository publishersRepo;

        public DataFilterController(IMechanicRepository mechanics, ICategoryRepository categories,
            IAuthorRepository authors, IArtistRepository artists, IPublisherRepository publishers)
        {
            this.mechanicsRepo = mechanics;
            this.categoriesRepo = categories;
            this.authorsRepo = authors;
            this.artistsRepo = artists;
            this.publishersRepo = publishers;
        }
        [HttpGet("GetData")]
        [Produces("application/json")]
        public async Task<ActionResult<StatsForFilterDto>> GetAllFilterData()
        {
            var artists = await artistsRepo.GetAll();
            var authors = await authorsRepo.GetAll();
            var mechanics = await mechanicsRepo.GetAll();
            var categories = await categoriesRepo.GetAll();
            var publishers = await publishersRepo.GetAll();
            var filtersData = new StatsForFilterDto
            {
                ArtistDtos = artists.ConvertToDto().ToList(),
                AuthorDtos = authors.ConvertToDto().ToList(),
                CategoryDtos = categories.ConvertToDto().ToList(),
                MechanicDtos = mechanics.ConvertToDto().ToList(),
                PublisherDtos = publishers.ConvertToDto().ToList()
            };
            return Ok(filtersData);
        }
    }
}
