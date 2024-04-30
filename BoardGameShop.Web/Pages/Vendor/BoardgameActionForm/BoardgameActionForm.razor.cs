using System;
using System.Reflection.Metadata.Ecma335;

namespace BoardGameShop.Web.Pages.Vendor.BoardgameActionForm
{
    public partial class BoardgameActionForm : ComponentBase
    {
        [Parameter]
        public EventCallback<BoardgameActionDto> SendToAction { get; set; }
        [Parameter]
        public bool ActionSuccess { get; set; }
        [Parameter]
        public string? ErrorMessage { get; set; }
        private bool isChanged = false;
        [Parameter]
        public BoardgameActionDto? Boardgame { get; set; }
        [Parameter]
        public StatsForFilterDto EntitiesInfo { get; set; }
        [Inject]
        public NavigationManager NavManager { get; set; }
        private bool IsPublisherChange { get => BoardgameChanging.Publisher?.Id != Boardgame?.Publisher?.Id; }
        private bool IsStatsChange
        {
            get => BoardgameChanging.MaxPlayer != Boardgame?.MaxPlayer
                || BoardgameChanging.MinPlayer != Boardgame?.MinPlayer
                || BoardgameChanging.MaxPlayTime != Boardgame?.MaxPlayTime
                || BoardgameChanging.MinPlayTime != Boardgame?.MinPlayTime
                || BoardgameChanging.Age != (Boardgame == null ? AgeEnum.None : Boardgame?.Age);
        }
        private bool IsPricingChange
        {
            get => BoardgameChanging.FullPrice != Boardgame?.FullPrice
                || BoardgameChanging.Discount != Boardgame.Discount;
        }
        private bool IsSeilingInfoChange
        {
            get => BoardgameChanging.IsDeleted != Boardgame?.IsDeleted
                || BoardgameChanging.Quantity != Boardgame?.Quantity;
        }
        public BoardgameActionDto BoardgameChanging { get; set; } = new();
        private string disabled = string.Empty;
        private string publisherBound = string.Empty;
        private readonly IEnumerable<AgeEnum> AgeList = Enum.GetValues(typeof(AgeEnum)).Cast<AgeEnum>();
        protected override Task OnInitializedAsync()
        {
            EntitiesInfo.CategoryDtos = EntitiesInfo.CategoryDtos
            .Where(c => !Boardgame.Categories.Select(gc => gc.Id).Contains(c.Id))
                .ToList();
            EntitiesInfo.MechanicDtos = EntitiesInfo.MechanicDtos
                .Where(i => !Boardgame.Mechanics.Select(gc => gc.Id).Contains(i.Id))
                .ToList();
            EntitiesInfo.AuthorDtos = EntitiesInfo.AuthorDtos
                .Where(i => !Boardgame.Authors.Select(gc => gc.Id).Contains(i.Id))
                .ToList();
            EntitiesInfo.ArtistDtos = EntitiesInfo.ArtistDtos
                .Where(i => !Boardgame.Artists.Select(gc => gc.Id).Contains(i.Id))
                .ToList();
            Boardgame.Age = Boardgame.Age ?? AgeEnum.None;

            BoardgameChanging.Publisher = Boardgame?.Publisher;

            BoardgameChanging.MaxPlayer = Boardgame?.MaxPlayer;
            BoardgameChanging.MinPlayer = Boardgame?.MinPlayer;
            BoardgameChanging.MaxPlayTime = Boardgame?.MaxPlayTime;
            BoardgameChanging.MinPlayTime = Boardgame?.MinPlayTime;
            BoardgameChanging.Age = Boardgame?.Age;
            BoardgameChanging.FullPrice = Boardgame.FullPrice;
            BoardgameChanging.Discount = Boardgame?.Discount;
            BoardgameChanging.Quantity = Boardgame.Quantity;
            BoardgameChanging.IsDeleted = Boardgame.IsDeleted;
            publisherBound = Boardgame?.Publisher?.Id.ToString() ?? "";
            return base.OnInitializedAsync();
        }
        private async void SendToAction_OnClick()
        {
            Boardgame.Publisher = BoardgameChanging.Publisher;
            Boardgame.Age = BoardgameChanging?.Age == AgeEnum.None ? null : BoardgameChanging?.Age;
            Boardgame.MinPlayer = BoardgameChanging?.MinPlayer;
            Boardgame.MaxPlayer = BoardgameChanging?.MaxPlayer;
            Boardgame.MaxPlayTime = BoardgameChanging?.MaxPlayTime;
            Boardgame.MinPlayTime = BoardgameChanging?.MinPlayTime;
            Boardgame.FullPrice = BoardgameChanging.FullPrice;
            Boardgame.Discount = BoardgameChanging?.Discount;
            Boardgame.IsDeleted = BoardgameChanging.IsDeleted;
            Boardgame.Quantity = BoardgameChanging.Quantity;
            await SendToAction.InvokeAsync(Boardgame);
            if (ActionSuccess)
            {
                BoardgameChanging = new();
                ResetPublisher_OnClick();
                ResetStats_OnClick();
                ResetPrice();
                ResetSeilingInfo();
                IsChangedUpdate();
                StateHasChanged();
            }
        }
        public void SetQuanity(int qty)
            => Boardgame.Quantity = qty;
        public void RemoveCategory(CategoryDto category)
        {
            disabled = "disabled";
            Boardgame?.Categories.RemoveAll(c => c.Id == category.Id);
            EntitiesInfo?.CategoryDtos.Add(category);
            CategoryChangeTracking(category);
            disabled = string.Empty;
            StateHasChanged();
        }

        public void AddCategory(CategoryDto category)
        {
            disabled = "disabled";
            Boardgame?.Categories.Add(category);
            EntitiesInfo?.CategoryDtos.RemoveAll(c => c.Id == category.Id);
            CategoryChangeTracking(category);
            disabled = string.Empty;
            StateHasChanged();

        }
        private void CategoryChangeTracking(CategoryDto category)
        {
            int changed = BoardgameChanging.Categories.RemoveAll(c => c.Id == category.Id);
            if (changed == 0)
                BoardgameChanging.Categories.Add(category);
            IsChangedUpdate();
        }
        public void ResetCategories()
        {
            disabled = "disabled";
            foreach (var category in BoardgameChanging.Categories)
            {
                if (Boardgame?.Categories.RemoveAll(c => c.Id == category.Id) == 0)
                {
                    Boardgame.Categories.Add(category);
                    EntitiesInfo?.CategoryDtos.RemoveAll(c => c.Id == category.Id);
                    continue;
                }
                EntitiesInfo?.CategoryDtos.Add(category);
            }
            BoardgameChanging.Categories.Clear();
            disabled = string.Empty;
            IsChangedUpdate();
            StateHasChanged();
        }
        public void UpdateMechanic(MechanicDto mechanic)
        {
            disabled = "disabled";
            if (Boardgame?.Mechanics.RemoveAll(m => m.Id == mechanic.Id) == 0)
            {
                Boardgame.Mechanics.Add(mechanic);
                EntitiesInfo?.MechanicDtos.RemoveAll(m => m.Id == mechanic.Id);
            }
            else
            {
                EntitiesInfo?.MechanicDtos.Add(mechanic);
            }
            MechanicChangeTracking(mechanic);
            disabled = string.Empty;
            StateHasChanged();
        }
        private void MechanicChangeTracking(MechanicDto mechanic)
        {
            int changed = BoardgameChanging.Mechanics.RemoveAll(c => c.Id == mechanic.Id);
            if (changed == 0)
                BoardgameChanging.Mechanics.Add(mechanic);
            IsChangedUpdate();
        }
        public void ResetMechanics()
        {
            disabled = "disabled";
            foreach (var mechanic in BoardgameChanging.Mechanics)
            {
                if (Boardgame?.Mechanics.RemoveAll(c => c.Id == mechanic.Id) == 0)
                {
                    Boardgame.Mechanics.Add(mechanic);
                    EntitiesInfo?.MechanicDtos.RemoveAll(c => c.Id == mechanic.Id);
                    continue;
                }
                EntitiesInfo?.MechanicDtos.Add(mechanic);
            }
            BoardgameChanging.Mechanics.Clear();
            disabled = string.Empty;
            IsChangedUpdate();
            StateHasChanged();
        }
        public void UpdateAuthor(AuthorDto author)
        {
            disabled = "disabled";
            if (Boardgame?.Authors.RemoveAll(m => m.Id == author.Id) == 0)
            {
                Boardgame.Authors.Add(author);
                EntitiesInfo?.AuthorDtos.RemoveAll(m => m.Id == author.Id);
            }
            else
            {
                EntitiesInfo?.AuthorDtos.Add(author);
            }
            AuthorChangeTracking(author);
            disabled = string.Empty;
            StateHasChanged();
        }
        private void AuthorChangeTracking(AuthorDto author)
        {
            int changed = BoardgameChanging.Authors.RemoveAll(c => c.Id == author.Id);
            if (changed == 0)
                BoardgameChanging.Authors.Add(author);
            IsChangedUpdate();
        }
        public void ResetAuthors()
        {
            disabled = "disabled";
            foreach (var author in BoardgameChanging.Authors)
            {
                if (Boardgame?.Authors.RemoveAll(c => c.Id == author.Id) == 0)
                {
                    Boardgame.Authors.Add(author);
                    EntitiesInfo?.AuthorDtos.RemoveAll(c => c.Id == author.Id);
                    continue;
                }
                EntitiesInfo?.AuthorDtos.Add(author);
            }
            BoardgameChanging.Authors.Clear();
            disabled = string.Empty;
            IsChangedUpdate();
            StateHasChanged();
        }
        public void UpdateArtist(ArtistDto artist)
        {
            disabled = "disabled";
            if (Boardgame?.Artists.RemoveAll(m => m.Id == artist.Id) == 0)
            {
                Boardgame.Artists.Add(artist);
                EntitiesInfo?.ArtistDtos.RemoveAll(m => m.Id == artist.Id);
            }
            else
            {
                EntitiesInfo?.ArtistDtos.Add(artist);
            }
            ArtistChangeTracking(artist);
            disabled = string.Empty;
            StateHasChanged();
        }
        private void ArtistChangeTracking(ArtistDto artist)
        {
            int changed = BoardgameChanging.Artists.RemoveAll(c => c.Id == artist.Id);
            if (changed == 0)
                BoardgameChanging.Artists.Add(artist);
            IsChangedUpdate();
        }
        public void ResetArtists()
        {
            disabled = "disabled";
            foreach (var artist in BoardgameChanging.Artists)
            {
                if (Boardgame?.Artists.RemoveAll(c => c.Id == artist.Id) == 0)
                {
                    Boardgame.Artists.Add(artist);
                    EntitiesInfo?.ArtistDtos.RemoveAll(c => c.Id == artist.Id);
                    continue;
                }
                EntitiesInfo?.ArtistDtos.Add(artist);
            }
            BoardgameChanging.Artists.Clear();
            disabled = string.Empty;
            IsChangedUpdate();
            StateHasChanged();
        }
        private void IsChangedUpdate()
        {
            isChanged = !(BoardgameChanging.IsCollectionsEqual(new BoardgameActionDto()))
                || IsPublisherChange
                || IsStatsChange
                || IsPricingChange
                || IsSeilingInfoChange;

        }
        public string PublisherBound
        {
            get
            {
                return publisherBound;
            }
            set
            {
                UpdatePublisher_OnClick(int.Parse(value));
                publisherBound = value;
            }
        }
        public void UpdatePublisher_OnClick(int publisherId)
        {
            BoardgameChanging.Publisher = EntitiesInfo?.PublisherDtos.First(p => p.Id == publisherId);
            IsChangedUpdate();
            StateHasChanged();
        }
        public void ResetPublisher_OnClick()
        {
            PublisherBound = Boardgame.Publisher.Id.ToString();
        }
        public void OnStatsChanging(int? minTime, int? maxTime, byte? minPlayer, byte? maxPlayer, AgeEnum? age)
        {
            //Console.WriteLine($"Input to changingTime : {minTime} - {maxTime}; players : {minPlayer} - {maxPlayer}; Age : {age}");
            //Console.WriteLine($"InBoardgame : Time : {Boardgame.MinPlayTime} - {Boardgame.MaxPlayTime}; " +
            //    $"players {Boardgame.MinPlayer} - {Boardgame.MaxPlayer}; Age : {Boardgame.Age}");
            BoardgameChanging.MaxPlayer = maxPlayer;
            BoardgameChanging.MinPlayer = minPlayer;
            BoardgameChanging.MaxPlayTime = maxTime;
            BoardgameChanging.MinPlayTime = minTime;
            BoardgameChanging.Age = age;
            IsChangedUpdate();
            StateHasChanged();
        }
        public void ResetStats_OnClick()
        {
            disabled = "disabled";
            BoardgameChanging.MaxPlayer = Boardgame?.MaxPlayer;
            BoardgameChanging.MinPlayer = Boardgame?.MinPlayer;
            BoardgameChanging.MaxPlayTime = Boardgame?.MaxPlayTime;
            BoardgameChanging.MinPlayTime = Boardgame?.MinPlayTime;
            BoardgameChanging.Age = Boardgame?.Age;
            IsChangedUpdate();
            disabled = string.Empty;
            StateHasChanged();
        }
        public void OnPriceChanging(decimal fullPrice, byte? discount)
        {
            disabled = "disabled";
            BoardgameChanging.FullPrice = fullPrice;
            BoardgameChanging.Discount = discount;
            IsChangedUpdate();
            disabled = string.Empty;
            StateHasChanged();
        }
        public void ResetPrice()
        {
            disabled = "disabled";
            BoardgameChanging.FullPrice = Boardgame.FullPrice;
            BoardgameChanging.Discount = Boardgame.Discount;
            IsChangedUpdate();
            disabled = string.Empty;
            StateHasChanged();
        }
        public void OnSeilingInfoChange(int qty, bool isDeleted)
        {
            disabled = "disabled";
            BoardgameChanging.IsDeleted = isDeleted;
            BoardgameChanging.Quantity = qty;
            IsChangedUpdate();
            disabled = string.Empty;
            StateHasChanged();
        }
        public void ResetSeilingInfo()
        {
            disabled = "disabled";
            BoardgameChanging.IsDeleted = Boardgame.IsDeleted;
            BoardgameChanging.Quantity = Boardgame.Quantity;
            IsChangedUpdate();
            disabled = string.Empty;
            StateHasChanged();
        }

    }
}
