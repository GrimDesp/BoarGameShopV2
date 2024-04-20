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
using BoardGameShop.Model.Dtos;
using BoardGameShop.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
var context = new ApplicationDbContextFactory().CreateDbContext(null);
//var category3 = context.Categories.Where(c => c.Id == 3).First();
//var category4 = context.Categories.Where(c => c.Id == 4).First();
//var game = new Boardgame
//{
//    Name = "AlsoRandom",
//    Categories = new List<Category> { category3, category4 },
//    FullPrice = 10,
//    VendorId = 1,
//    PublisherId = 1
//};
//context.BoardGames.Add(game);
//context.SaveChanges();
var game = context.BoardGames.First(g => g.Name == "AlsoRandom");
Console.WriteLine("Before creating toCategory list : " + ByteArrayToString(game.TimeSpam));
var category3 = new List<BoardgameToCategory> { new BoardgameToCategory { BoardgameId = game.Id, CategoryId = 2 } };
game.BoardgameCategories = category3;
Console.WriteLine("After adding toCategory list : " + ByteArrayToString(game.TimeSpam));
context.BoardGames.Update(game);
context.SaveChanges();
Console.WriteLine("toCategory list in tracker : ");
//В обєкті game буде обновлятись тайм стамп і буде рівний бд, але при цьому в трекері буде тік той список, який равний category3 
foreach (var categoryItem in game.BoardgameCategories)
    Console.WriteLine($" -> {categoryItem.CategoryId}");

Console.WriteLine("After SaveChanges : " + ByteArrayToString(game.TimeSpam));
context.ChangeTracker.Clear();
Console.WriteLine("From db : " + ByteArrayToString(context.BoardGames.First(g => g.Id == game.Id).TimeSpam));

Console.WriteLine("toCategory list in db : ");
foreach (var categoryItem in context.BoardGames.Include(g => g.BoardgameCategories).First(g => g.Id == 14).BoardgameCategories)
    Console.WriteLine($" -> {categoryItem.CategoryId}");

Console.WriteLine("Done");
Console.ReadLine();

string ByteArrayToString(byte[] data)
{
    string str = "";
    foreach (var item in data)
        str += item.ToString();
    return str;
}
