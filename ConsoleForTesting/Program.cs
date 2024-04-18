/*
// See https://aka.ms/new-console-template for more information
using BoardGameShop.DAL.EfStructures;

var dirPath = Directory.GetFiles($"D:\\University\\4\\2сем\\БКР\\Test\\BoardGameShop\\BoardGameShop.Api\\data\\img").First();
Console.WriteLine($"{dirPath}");
DirectoryInfo dir = new DirectoryInfo("..\\..\\..\\data\\img\\BoardGames");
Console.WriteLine(dir.FullName);
Directory.GetFiles(dir.FullName, "*");
foreach (var file in dir.GetFiles())
{
    Console.WriteLine(file);
}
 */
using BoardGameShop.DAL.EfStructures;
using BoardGameShop.DAL.Entities;
using BoardGameShop.DAL.Repositories;
using BoardGameShop.DAL.Repositories;
using BoardGameShop.Model.Dtos;
using BoardGameShop.Model.Enums;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
Console.WriteLine(Role.Publisher.ToString());
var context = new ApplicationDbContextFactory().CreateDbContext(null);
var gameRepo = new BoardGameRepository(context);
var orderRepo = new OrderRepository(context);
var game = await gameRepo.GetById(1);
Console.WriteLine(game.VendorNavigation.Name);
Console.WriteLine();
var orders = new List<CreateOrderDto>();
orders.Add(new CreateOrderDto
{
    User = new UserPersonalInfoDto { Firstname = "Sergo" },
    VendorId = 3,
    Items = new List<OrderItemDto>
    {
        new OrderItemDto
        {
            Id = 6,
            Qty = 2,
            TimeStamp = gameRepo.Table.First( g=> g.Id == 6).TimeSpam
        }
    },
});
await CreateOrders(orders);
Console.ReadLine();
async Task CreateOrders(IEnumerable<CreateOrderDto> request)
{
    try
    {
        int id = 1;
        foreach (var order in request)
        {
            var games = await gameRepo.GetByVendor(order.VendorId)
                .Where(g => order.Items.Select(i => i.Id).Contains(g.Id))
                .Select(g => new Boardgame
                {
                    Name = g.Name,
                    Id = g.Id,
                    VendorId = g.VendorId,
                    TimeSpam = g.TimeSpam,
                    FullPrice = g.FullPrice,
                    Discount = g.Discount,
                    Quantity = g.Quantity
                })
                .ToListAsync();
            foreach (var item in order.Items)
            {
                var game = games.SingleOrDefault(g => g.Id == item.Id);
                if (game == null)
                {
                }
                if (!game.TimeSpam.SequenceEqual(item.TimeStamp))
                {
                    //new { game.TimeSpam, item.TimeStamp, game.Id, orderId = item.Id }
                }
                if (game.Quantity < item.Qty)
                {
                }

            }
            var orderItems = ConvertToEntity(order.Items).ToList();
            orderItems.ForEach(oi => oi.ItemCost = GetPrice(games.Single(g => g.Id == oi.ItemId), oi.Qty));
            var orderEntity = new Order
            {
                UserId = id,
                VendorId = order.VendorId,
                DeliveryAddress = order.DeliveryAddress,
                Firstname = order.User.Firstname,
                Lastname = order.User.Lastname,
                Secondname = order.User.Secondname,
                OrderItems = orderItems,
            };

            await orderRepo.Add(orderEntity, persiste: false);
        }
        await orderRepo.SaveChanges();
        return;
    }
    catch (Exception ex)
    {
        throw ex;
    }
}
IEnumerable<OrderItem> ConvertToEntity(IEnumerable<OrderItemDto> orders)
    => orders.Select(o => new OrderItem { ItemId = o.Id, Qty = o.Qty });
int GetPrice(Boardgame game, int qty)
{
    if (game.Discount != null)
        return (int)Math.Ceiling(game.FullPrice * (1 - ((decimal)game.Discount / 100)) * qty);
    return (int)Math.Ceiling(game.FullPrice * qty);
}