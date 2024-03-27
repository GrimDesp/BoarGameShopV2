// See https://aka.ms/new-console-template for more information
var dirPath = Directory.GetFiles($"D:\\University\\4\\2сем\\БКР\\Test\\BoardGameShop\\BoardGameShop.Api\\data\\img").First();
Console.WriteLine($"{dirPath}");
DirectoryInfo dir = new DirectoryInfo("..\\..\\..\\data\\img\\BoardGames");
Console.WriteLine(dir.FullName);
Directory.GetFiles(dir.FullName, "*");
foreach (var file in dir.GetFiles())
{
    Console.WriteLine(file);
}