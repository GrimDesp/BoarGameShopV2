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
        public string deliveryAddress { get; set; } = string.Empty;
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
        private async Task RemoveOrder(string vendorName)
        {
            inRequest = true;
            try
            {
                await OrderService.RemoveOrderByVendor(vendorName);
                OrdersByName = await OrderService.GetItemsGroupByVendor();
                inRequest = false;
                StateHasChanged();
            }
            catch (Exception ex)
            {
                inRequest = false;
                InitErrorMessage = ex.Message;
                StateHasChanged();
            }
        }
        private async Task CreateOrders_OnClick()
        {
            inRequest = true;
            Orders.Clear();
            foreach (var item in OrdersByName)
            {
                Orders.Add(new OrderDto
                {
                    DeliveryAddress = deliveryAddress,
                    Items = item.Value.ConvertToDto(),
                    VendorId = item.Value.First().VendorId,
                    User = user
                });
            }
            try
            {
                await OrderService.SendOrders(Orders);
                navManager.NavigateTo("/orders");
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
    }
}
