using System.Reflection.Metadata.Ecma335;

namespace BoardGameShop.Api.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<BoardGame> games)
        {
            return (from boardGame in games
                    select new ProductDto()
                    {
                        Id = boardGame.Id,
                        Discount = boardGame.Discount,
                        FullPrice = boardGame.FullPrice,
                        Name = boardGame.Name,
                        Quantity = boardGame.Quantity,
                        MinPlayer = boardGame.MinPlayer,
                        MaxPlayer = boardGame.MaxPlayer,
                        MinPlayTime = boardGame.MinPlayTime,
                        MaxPlayTime = boardGame.MaxPlayTime,
                        Age = boardGame.Age,
                        ImageUrl = LoadImageUlr(boardGame.Id),
                        Price = boardGame.Discount > 0 ? CalculatePrice(boardGame.FullPrice, boardGame.Discount ?? 0) : default
                    }).ToList();
        }
        public static IEnumerable<PersonDto> ConvertToDto(this IEnumerable<Artist> artists)
            => artists.Select(artist => new PersonDto { Id = artist.Id, Name = artist.FullName });
        public static IEnumerable<PersonDto> ConvertToDto(this IEnumerable<Author> authors)
            => authors.Select(author => new PersonDto { Id = author.Id, Name = author.FullName });
        public static IEnumerable<CategoryDto> ConvertToDto(this IEnumerable<Category> categories)
            => categories.Select(category => new CategoryDto { Id = category.Id, CategoryName = category.Name });
        public static IEnumerable<MechanicDto> ConvertToDto(this IEnumerable<Mechanic> mechanics)
            => mechanics.Select(mechanic => new MechanicDto { MechanicId = mechanic.Id, MechanicName = mechanic.Name });
        public static IEnumerable<PublisherDto> ConvertToDto(this IEnumerable<Publisher> publishers)
            => publishers.Select(publisher => new PublisherDto { Id = publisher.Id, PublisherName = publisher.Name });
        private static string LoadImageUlr(int itemId)
        {
            try
            {
                string? image = Directory.GetFiles($"..\\BoardGameShop.Web\\wwwroot\\data\\img\\BoardGames\\{itemId}").FirstOrDefault();
                if (image is null)
                    throw new DirectoryNotFoundException();
                image = image.Replace("..\\BoardGameShop.Web\\wwwroot", "");
                return image;
            }
            catch (DirectoryNotFoundException)
            {
                return "\\data\\img\\Default.png";
            }
        }
        private static decimal CalculatePrice(decimal fullPrice, byte discount)
            => fullPrice * (1 - (discount / (decimal)100));
    }
}
