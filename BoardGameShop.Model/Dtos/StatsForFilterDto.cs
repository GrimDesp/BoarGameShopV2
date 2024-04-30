namespace BoardGameShop.Model.Dtos
{
    public class StatsForFilterDto
    {
        public List<MechanicDto> MechanicDtos { get; set; } = new();
        public List<CategoryDto> CategoryDtos { get; set; } = new();
        public List<AuthorDto> AuthorDtos { get; set; } = new();
        public List<ArtistDto> ArtistDtos { get; set; } = new();
        public List<PublisherDto> PublisherDtos { get; set; } = new();
    }
    public class MechanicDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public abstract class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class AuthorDto : PersonDto
    {

    }
    public class ArtistDto : PersonDto { }
    public class PublisherDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
