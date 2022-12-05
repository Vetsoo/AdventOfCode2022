Console.WriteLine("Welcome to the DAY 1!");
Console.WriteLine("");
Console.WriteLine("Started reading input...");
var inputText = await File.ReadAllTextAsync(@"Input/input.txt");
var combinedCaloriesForHighestCaloriesCarryingElf = inputText
    .Split("\r\n\r\n")
    .Select(x =>
    x.Split("\r\n").Select(long.Parse).Sum())
    .OrderByDescending(x => x)
    .First();

var combinedCaloriesForHighestCaloriesCarryiedByTop3Elfs = inputText
    .Split("\r\n\r\n")
    .Select(x =>
    x.Split("\r\n").Select(long.Parse).Sum())
    .OrderByDescending(x => x)
    .Take(3)
    .Sum();

Console.WriteLine($"Most calories for an elf: {combinedCaloriesForHighestCaloriesCarryingElf}");
Console.WriteLine($"Most calories for top 3 elfs: {combinedCaloriesForHighestCaloriesCarryiedByTop3Elfs}");
Console.ReadLine();