using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoardGameShop.Web.Pages
{
    public partial class Orders : ComponentBase
    {
        [Inject]
        public IOrderService OrderService { get; set; }
        public string? InitErrorMessage { get; set; }
        public List<OrderDetailsDto>? OrdersList { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                var items = await OrderService.GetUserOrders();
                OrdersList = items.ToList();
            }
            catch (Exception ex)
            {
                InitErrorMessage = ex.Message;
            }
        }
        private string GetBorderColor(OrderStatus status)
        {
            string borderColor;
            switch (status)
            {
                case OrderStatus.Created:
                    borderColor = "border-warning";
                    break;
                case OrderStatus.InProcess:
                    borderColor = "border-info";
                    break;
                case OrderStatus.Cancel:
                    borderColor = "border-secondary";
                    break;
                case OrderStatus.Complete:
                    borderColor = "border-success";
                    break;
                case OrderStatus.Delivered:
                    borderColor = "border-danger";
                    break;
                default:
                    borderColor = "border-danger";
                    break;
            }
            return borderColor;
        }
    }
}
