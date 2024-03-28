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
                        ImageUrls = LoadImagesUlr(boardGame.Id),
                        Price = boardGame.Discount > 0 ? CalculatePrice(boardGame.FullPrice, boardGame.Discount ?? 0) : default
                    }).ToList();
        }

        private static IEnumerable<string> LoadImagesUlr(int itemId)
        {
            try
            {
                IEnumerable<string> images = Directory.GetFiles($"..\\BoardGameShop.Web\\wwwroot\\data\\img\\BoardGames\\{itemId}");
                if (images.Count() == 0)
                    throw new DirectoryNotFoundException();
                images = images.Select(str => str.Replace("..\\BoardGameShop.Web\\wwwroot", ""));
                return images;
            }
            catch (DirectoryNotFoundException)
            {
                return new List<string>(["\\data\\img\\Default.png"]);
            }
        }
        private static decimal CalculatePrice(decimal fullPrice, byte discount)
            => fullPrice * (1 - (discount / (decimal)100));
    }
}
