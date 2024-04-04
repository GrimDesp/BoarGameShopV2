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
using ConsoleForTesting;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
int[] _mechanicIds = { 2, 5 };
int[] _categoriesIds = { 1, 4 };
int totalItems = 0;
var context = new ApplicationDbContextFactory().CreateDbContext(null);

var gamesName = context.BoardGames.AsQueryable<Boardgame>();
List<Func<IQueryable<Boardgame>, IQueryable<Boardgame>>> filterCollection = new();
filterCollection.Add(CategoryFilter);
filterCollection.Add(MechanicsFilter);
filterCollection.Add(CountGames);
/*
 * Не робит. Замість визова методів в стекові делегата вони ігноряться.

gamesName = filterCollection(gamesName);
or 
gamesName = filterCollection.Invoke(gamesName);
Як варіант перевірити шо робить метод 
filterCollection.GetInvocationList();
Возможно це позволить через цикл foreach визвати кожний делегат окремо і тоді конфлікта методів в стекові не буде 
Неа оказалось юзлес 
Зато через масів делегатів сработало 
*/
foreach (var method in filterCollection)
{
    gamesName = method.Invoke(gamesName);
}
//gamesName = MechanicsFilter(gamesName);
//gamesName = CategoryFilter(gamesName);
//gamesName = CountGames(gamesName);
//var gameList = gamesName.Select(g => new CustomData { Id = g.Id, Name = g.Name }).ToList();
var gameList = gamesName.Include(g => g.Mechanics).Select(g => new { Name = g.Name, Id = g.Id, Mechanics = g.Mechanics.Select(m => m.Name) }).ToList();
foreach (var gameName in gameList)
{
    Console.WriteLine(gameName);
}
Console.WriteLine(totalItems);
Console.WriteLine();
context.ChangeTracker.Clear();
//var games = context.BoardGames.Include(g => g.Mechanics).Select(g => new { Name = g.Name, Id = g.Id, Mechanics = g.Mechanics.Select(m => m.Name) });
foreach (var game in gameList)
{
    Console.WriteLine($"{game.Name} with {game.Id} have : ");
    if (game.Mechanics == null || game.Mechanics.Count() == 0)
    {
        Console.WriteLine(" -> ...No mechanics");
        continue;
    }
    foreach (var m in game.Mechanics)
    {
        Console.WriteLine($" -> {m}");
    }
}
Console.WriteLine("Type Enter");
Console.ReadLine();
IQueryable<Boardgame> CountGames(IQueryable<Boardgame> game)
{
    totalItems = game.Count();
    return game;
}
IQueryable<Boardgame> MechanicsFilter(IQueryable<Boardgame> game)
{
    return game.Include(g => g.BoardgameMechanics).Where(g => g.BoardgameMechanics.Where(bg => _mechanicIds.Contains(bg.MechanicId)).Any());
}
IQueryable<Boardgame> CategoryFilter(IQueryable<Boardgame> games)
{
    return games.Include(g => g.BoardgameCategories).Where(g => g.BoardgameCategories.Where(bg => _categoriesIds.Contains(bg.CategoryId)).Any());
}

