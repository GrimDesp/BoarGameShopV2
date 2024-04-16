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
using BoardGameShop.DAL.Repositories;
using BoardGameShop.Model.Enums;
using Microsoft.EntityFrameworkCore;
Console.WriteLine(Role.Publisher.ToString());
var context = new ApplicationDbContextFactory().CreateDbContext(null);
var bgRepo = new BoardGameRepository(context);
var game = await bgRepo.GetById(1);
Console.WriteLine(game.VendorNavigation.Name);
