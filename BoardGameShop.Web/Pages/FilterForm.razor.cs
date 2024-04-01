namespace BoardGameShop.Web.Pages
{
    public partial class FilterForm : ComponentBase
    {
        private int minPlayers = 1;
        private int maxPlayers = 10;

        public int MinPlayers
        {
            get => minPlayers; set
            {
                if (value <= 0) minPlayers = 1;
                if (value > maxPlayers) return;
                minPlayers = value;
            }
        }
        public int MaxPlayers
        {
            get => maxPlayers; set
            {
                if (value <= 0) maxPlayers = 10;
                if (value < minPlayers) return;
                maxPlayers = value;
            }
        }
    }
}
