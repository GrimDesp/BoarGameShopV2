namespace BoardGameShop.Web.Pages
{
    public partial class PaginationButtonGroup : ComponentBase
    {
        [Parameter]
        public EventCallback<int> eventCallback { get; set; }
        [Parameter]
        public int TotalPages { get; set; }
        [Parameter]
        public int CurrentPage { get; set; }
        private async Task OnPaginationClick(MouseEventArgs e, int buttonNumber)
            => await eventCallback.InvokeAsync(buttonNumber);
    }
}
