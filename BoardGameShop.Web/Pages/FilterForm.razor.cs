
using System.ComponentModel;

namespace BoardGameShop.Web.Pages
{
    public partial class FilterForm : ComponentBase
    {
        public string? Message { get; set; }
        public RequestFormFilter FormData { get; set; }
        public StatsForFilterDto FilterData { get; set; } = new StatsForFilterDto();
        [Inject]
        public IProductService ProductService { get; set; }
        [Parameter]
        public EventCallback<RequestFormFilter> EventCallback { get; set; }
        public string? ErrorMessage { get; set; }
        private int minPlayers = 1;
        private int maxPlayers = 10;
        private int minPrice = 0;
        private int maxPrice;
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
        public int MinPrice
        {
            get => minPrice; set
            {
                if (value <= 0) return;
                else if (value > maxPrice) return;
                minPrice = value;
            }
        }
        public int MaxPrice
        {
            get => maxPrice; set
            {
                if (value <= 0) return;
                else if (value < minPrice) return;
                maxPrice = value;
            }
        }
        public Dictionary<int, bool> MechanicIdsFilter { get; set; } = new Dictionary<int, bool>();
        public Dictionary<int, bool> CategoryIdsFilter { get; set; } = new Dictionary<int, bool>();
        public Dictionary<int, bool> PublisherIdsFilter { get; set; } = new Dictionary<int, bool>();
        public Dictionary<int, bool> AuthorIdsFilter { get; set; } = new Dictionary<int, bool>();
        public Dictionary<int, bool> ArtistIdsFilter { get; set; } = new Dictionary<int, bool>();
        protected async override Task OnInitializedAsync()
        {
            try
            {
                FilterData = await ProductService.GetStatsForFilterAsync();
                InitializeDicts();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        public async Task UpdateProducts()
        {
            FormData = new RequestFormFilter
            {
                ArtistIds = ArtistIdsFilter.Where(value => value.Value).Select(value => value.Key),
                AuthorIds = AuthorIdsFilter.Where(value => value.Value).Select(value => value.Key),
                MechanicIds = MechanicIdsFilter.Where(value => value.Value).Select(value => value.Key),
                CategoryIds = CategoryIdsFilter.Where(value => value.Value).Select(value => value.Key),
                PublisherIds = PublisherIdsFilter.Where(value => value.Value).Select(value => value.Key),
                MaxPlayers = maxPlayers,
                MinCost = minPrice,
                MaxCost = maxPrice,
                MinPlayers = minPlayers
            };
            await EventCallback.InvokeAsync(FormData);
        }
        private void InitializeDicts()
        {
            foreach (var item in FilterData.MechanicDtos)
            {
                MechanicIdsFilter.Add(item.MechanicId, false);
            }
            foreach (var item in FilterData.CategoryDtos)
            {
                CategoryIdsFilter.Add(item.Id, false);
            }
            foreach (var item in FilterData.PublisherDtos)
            {
                PublisherIdsFilter.Add(item.Id, false);
            }
            foreach (var item in FilterData.AuthorDtos)
            {
                AuthorIdsFilter.Add(item.Id, false);
            }
            foreach (var item in FilterData.ArtistDtos)
            {
                ArtistIdsFilter.Add(item.Id, false);
            }
        }
    }
}
