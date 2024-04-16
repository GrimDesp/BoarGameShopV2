using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoardGameShop.Web.Pages
{
    public partial class CreateOrders : ComponentBase
    {
        [Inject]
        public NavigationManager? navManager { get; set; }
        [Inject]
        public IAuthService? AuthService { get; set; }
        [Inject]
        public IOrderService? OrderService { get; set; }

        public UserPersonalInfoDto? user { get; set; }
        public List<OrderDto> Orders { get; set; } = new();
        public Dictionary<string, List<CartItem>>? OrdersByName { get; set; }
        private string errorMessage = string.Empty;
        private bool inRequest = false;
        public string? InitErrorMessage { get; set; }
        protected async override Task OnInitializedAsync()
        {
            try
            {
                user = await AuthService.GetUserData() ?? new UserPersonalInfoDto();
                OrdersByName = await OrderService.GetItemsGroupByVendor();
            }
            catch (Exception ex)
            {
                InitErrorMessage = ex.Message;
            }
        }
    }
}
