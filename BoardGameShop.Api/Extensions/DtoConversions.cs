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
                VendorId = game.VendorNavigation.Id,
                VendorName = game.VendorNavigation.Name,
                ImageUrls = LoadImageUrls(game.Id).ToList()
            };
        }
        public static IEnumerable<ArtistDto> ConvertToDto(this IEnumerable<Artist> artists)
            => artists.Select(artist => new ArtistDto { Id = artist.Id, Name = artist.FullName });
        public static IEnumerable<AuthorDto> ConvertToDto(this IEnumerable<Author> authors)
            => authors.Select(author => new AuthorDto { Id = author.Id, Name = author.FullName });
        public static IEnumerable<CategoryDto> ConvertToDto(this IEnumerable<Category> categories)
            => categories.Select(category => new CategoryDto { Id = category.Id, Name = category.Name });
        public static IEnumerable<MechanicDto> ConvertToDto(this IEnumerable<Mechanic> mechanics)
            => mechanics.Select(mechanic => new MechanicDto { Id = mechanic.Id, Name = mechanic.Name });
        public static IEnumerable<PublisherDto> ConvertToDto(this IEnumerable<Publisher> publishers)
            => publishers.Select(publisher => new PublisherDto { Id = publisher.Id, Name = publisher.Name });
        public static IEnumerable<OrderItemInfoDto> ConvertToDto(this IEnumerable<OrderItem> orderItems)
            => orderItems.Select(oi => new OrderItemInfoDto
            {
                Id = oi.ItemId,
                Price = oi.ItemCost,
                Quantity = oi.Qty,
                ImageUrl = LoadImageUrl(oi.ItemId)
            });
        public static IEnumerable<OrderItem> ConvertToEntity(this IEnumerable<OrderItemDto> orders)
            => orders.Select(o => new OrderItem { ItemId = o.Id, Qty = o.Qty });
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
        public static BoardgameActionDto ConvertToActionDto(this Boardgame boardgame)
            => new BoardgameActionDto
            {
                Name = boardgame.Name,
                Id = boardgame.Id,
                TimeStamp = boardgame.TimeSpam,
                Age = boardgame.Age,
                Description = boardgame.Description,
                Discount = boardgame.Discount,
                FullPrice = boardgame.FullPrice,
                IsDeleted = boardgame.IsDeleted,
                MaxPlayer = boardgame.MaxPlayer,
                MaxPlayTime = boardgame.MaxPlayTime,
                MinPlayer = boardgame.MinPlayer,
                MinPlayTime = boardgame.MinPlayTime,
                Quantity = boardgame.Quantity,
                Artists = boardgame.Artists.Select(a => new ArtistDto { Name = a.FullName, Id = a.Id }).ToList(),
                Authors = boardgame.Authors.Select(a => new AuthorDto { Name = a.FullName, Id = a.Id }).ToList(),
                Categories = boardgame.Categories.Select(c => new CategoryDto { Name = c.Name, Id = c.Id }).ToList(),
                Mechanics = boardgame.Mechanics.Select(m => new MechanicDto { Name = m.Name, Id = m.Id }).ToList(),
                Publisher = new PublisherDto { Name = boardgame.PublisherNavigation.Name, Id = boardgame.PublisherNavigation.Id }
            };
        public static Boardgame ConvertToEntity(this BoardgameActionDto boardgameDto)
            => new Boardgame
            {
                TimeSpam = boardgameDto.TimeStamp,
                Age = boardgameDto.Age,
                Description = boardgameDto.Description,
                Discount = boardgameDto.Discount,
                FullPrice = boardgameDto.FullPrice,
                IsDeleted = boardgameDto.IsDeleted,
                MaxPlayer = boardgameDto.MaxPlayer,
                MaxPlayTime = boardgameDto.MaxPlayTime,
                MinPlayer = boardgameDto.MinPlayer,
                MinPlayTime = boardgameDto.MinPlayTime,
                Name = boardgameDto.Name,
                PublisherId = boardgameDto.Publisher.Id,
                Quantity = boardgameDto.Quantity,
                BoardgameArtists = boardgameDto.Artists
                .Select(a => new BoardgameToArtist { ArtistId = a.Id, BoardgameId = boardgameDto.Id }).ToList(),
                BoardgameAuthors = boardgameDto.Authors
                .Select(a => new BoardgameToAuthor { AuthorId = a.Id, BoardgameId = boardgameDto.Id }).ToList(),
                BoardgameCategories = boardgameDto.Categories
                .Select(c => new BoardgameToCategory { CategoryId = c.Id, BoardgameId = boardgameDto.Id }).ToList(),
                BoardgameMechanics = boardgameDto.Mechanics
                .Select(m => new BoardgameToMechanic { MechanicId = m.Id, BoardgameId = boardgameDto.Id }).ToList(),

            };
    }
}
