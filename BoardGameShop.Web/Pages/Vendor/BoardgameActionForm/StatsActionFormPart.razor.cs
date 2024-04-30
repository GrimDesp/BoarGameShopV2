namespace BoardGameShop.Web.Pages.Vendor.BoardgameActionForm
{
    public partial class StatsActionFormPart : ComponentBase, IDisposable
    {
        private AgeEnum? age;
        private int? maxPlayerTime;
        private int? minPlayTime;
        private byte? maxPlayer;
        private byte? minPlayer;

        [Parameter]
        public int? MaxPlayTime
        {
            get => maxPlayerTime;
            set
            {
                if (value <= 0)
                    return;
                if (value == maxPlayerTime) return;
                if (minPlayTime == null)
                {
                    maxPlayerTime = value;
                    OnPropertyChanged();
                    return;
                }
                if (value < minPlayTime)
                {
                    maxPlayerTime = maxPlayerTime >= minPlayTime ? maxPlayerTime : minPlayTime;
                    return;
                }
                maxPlayerTime = value;
                OnPropertyChanged();
            }
        }
        [Parameter]
        public int? MinPlayTime
        {
            get => minPlayTime;
            set
            {
                if (value <= 0)
                    return;
                if (value == minPlayTime) return;
                if (MaxPlayTime == null)
                {
                    minPlayTime = value;
                    OnPropertyChanged();
                    return;
                }
                if (value > maxPlayerTime)
                {
                    minPlayTime = maxPlayerTime >= minPlayTime ? minPlayTime : maxPlayerTime;
                    return;
                }
                minPlayTime = value;
                OnPropertyChanged();
            }
        }
        [Parameter]
        public byte? MaxPlayer
        {
            get => maxPlayer;
            set
            {
                if (value <= 0)
                    return;
                if (value == maxPlayer)
                    return;
                if (minPlayer == null)
                {
                    maxPlayer = value;
                    OnPropertyChanged();
                    return;
                }
                if (value < minPlayer)
                {
                    maxPlayer = maxPlayer >= minPlayer ? maxPlayer : minPlayer;
                    return;
                }
                maxPlayer = value;
                OnPropertyChanged();
            }
        }
        [Parameter]
        public byte? MinPlayer
        {
            get => minPlayer;
            set
            {
                if (value <= 0)
                    return;
                if (value == minPlayer)
                    return;
                if (maxPlayer == null)
                {
                    minPlayer = value;
                    OnPropertyChanged();
                    return;
                }
                if (value > maxPlayer)
                {
                    minPlayer = maxPlayer >= minPlayer ? minPlayer : maxPlayer;
                    return;
                }
                minPlayer = value;
                OnPropertyChanged();
            }
        }
        [Parameter]
        public AgeEnum? Age
        {
            get => age; set
            {
                if (value == age)
                    return;
                age = value;
                OnPropertyChanged();
            }
        }
        [Parameter]
        public bool IsChanged { get; set; }
        [Parameter]
        public string Disabled { get; set; } = string.Empty;
        [Parameter]
        public Action<int?, int?, byte?, byte?, AgeEnum?>? Action { get; set; }
        [Parameter]
        public EventCallback ResetCallback { get; set; }
        [Parameter]
        public IEnumerable<AgeEnum>? AgeList { get; set; }

        public void Dispose()
        {
            Action = null;
        }
        private void OnPropertyChanged()
        {
            Action?.Invoke(MinPlayTime, MaxPlayTime, MinPlayer, MaxPlayer, Age);
        }
    }
}
