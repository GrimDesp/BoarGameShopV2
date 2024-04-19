namespace BoardGameShop.Model.Dtos.VendorControl
{
    public class BoardgameDeleteChangeDto
    {
        public int Id { get; set; }
        public required byte[] TimeStamp { get; set; }
        public bool IsDeleted { get; set; }
    }
}
