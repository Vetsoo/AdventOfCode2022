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
Console.WriteLine($"Most calories for an elf: {combinedCaloriesForHighestCaloriesCarryingElf}");
Console.ReadLine();