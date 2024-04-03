namespace BoardGameShop.Model.Dtos
{
    public class StatsForFilterDto
    {
        public List<MechanicDto> MechanicDtos { get; set; } = new();
        public IEnumerable<CategoryDto> CategoryDtos { get; set; } = Enumerable.Empty<CategoryDto>();
        public IEnumerable<PersonDto> AuthorDtos { get; set; } = Enumerable.Empty<PersonDto>();
        public IEnumerable<PersonDto> ArtistDtos { get; set; } = Enumerable.Empty<PersonDto>();
        public IEnumerable<PublisherDto> PublisherDtos { get; set; } = Enumerable.Empty<PublisherDto>();
    }
    public class MechanicDto
    {
        public int MechanicId { get; set; }
        public string MechanicName { get; set; } = string.Empty;
    }
    public class CategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class PublisherDto
    {
        public int Id { get; set; }
        public string PublisherName { get; set; } = string.Empty;
    }
}
