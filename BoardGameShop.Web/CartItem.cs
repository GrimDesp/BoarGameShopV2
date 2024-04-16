namespace BoardGameShop.Web
{
    public class CartItem
    {
        public int Id { get; set; }
        public int VendorId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string PublisherName { get; set; } = string.Empty;
        public string VendorName { get; set; } = string.Empty;

        public int Quantity { get; set; }
        public byte[] TimeStamp { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
