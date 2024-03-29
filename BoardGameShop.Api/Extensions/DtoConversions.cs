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
                        ImageUrl = LoadImageUlr(boardGame.Id),
                        Price = boardGame.Discount > 0 ? CalculatePrice(boardGame.FullPrice, boardGame.Discount ?? 0) : default
                    }).ToList();
        }

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
