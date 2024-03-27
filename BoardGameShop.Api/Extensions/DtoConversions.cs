
using Microsoft.EntityFrameworkCore.Migrations;

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
                        ImageUrls = LoadImagesUlr(boardGame.Id)
                    }).ToList();
        }

        private static IEnumerable<string> LoadImagesUlr(int itemId)
        {
            try
            {
                var images = Directory.GetFiles($".\\data\\img\\BoardGames\\{itemId}");
                if (images.Length == 0)
                    throw new DirectoryNotFoundException();
                return images;
            }
            catch (DirectoryNotFoundException)
            {
                return Directory.GetFiles(".\\data\\img");
            }
        }
    }
}
