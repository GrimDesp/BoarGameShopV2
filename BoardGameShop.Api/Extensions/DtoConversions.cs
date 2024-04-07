using BoardGameShop.DAL.Entities;
using System.Reflection.Metadata.Ecma335;

namespace BoardGameShop.Api.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Boardgame> games)
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
                        ImageUrl = LoadImageUrl(boardGame.Id),
                        Price = boardGame.Discount > 0 ? CalculatePrice(boardGame.FullPrice, boardGame.Discount ?? 0) : default
                    }).ToList();
        }
        public static ProductDetailsDto ConvertToDto(this Boardgame game)
        {
            return new ProductDetailsDto
            {
                Age = game.Age,
                ProductId = game.Id,
                Artists = game.Artists.Select(a => a.FullName),
                Authors = game.Authors.Select(a => a.FullName),
                Categories = game.Categories.Select(c => c.Name),
                Mechanics = game.Mechanics.Select(m => m.Name),
                Description = game.Description,
                FullPrice = game.FullPrice,
                IsAvaible = game.Quantity > 0,
                MaxPlayer = game.MaxPlayer,
                MinPlayer = game.MinPlayer,
                MaxPlayTime = game.MaxPlayTime,
                MinPlayTime = game.MinPlayTime,
                Price = game.Discount > 0 ? CalculatePrice(game.FullPrice, (byte)game.Discount) : null,
                ProductName = game.Name,
                PublisherName = game.PublisherNavigation.Name,
                TimeSpam = game.TimeSpam,
                ImageUrls = LoadImageUrls(game.Id).ToList()
            };
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
        private static string LoadImageUrl(int itemId)
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
        private static string[] LoadImageUrls(int itemId)
        {
            try
            {
                string[] image = Directory.GetFiles($"..\\BoardGameShop.Web\\wwwroot\\data\\img\\BoardGames\\{itemId}");
                if (image is null)
                    throw new DirectoryNotFoundException();
                for (int i = 0; i < image.Length; i++)
                    image[i] = image[i].Replace("..\\BoardGameShop.Web\\wwwroot", "");
                return image;
            }
            catch (DirectoryNotFoundException)
            {
                return ["\\data\\img\\Default.png"];
            }
        }
        private static decimal CalculatePrice(decimal fullPrice, byte discount)
            => fullPrice * (1 - (discount / (decimal)100));
    }
}
