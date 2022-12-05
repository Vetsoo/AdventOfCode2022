Console.WriteLine("Welcome to the DAY 3!");
Console.WriteLine("");
Console.WriteLine("Started reading input...");
var inputText = await File.ReadAllLinesAsync(@"Input/input.txt");

const string _letterValues = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

var sacksWithCompartments = inputText.Select(x => x.Insert(x.Length / 2, "|").Split("|"));
var totalSumOfAllDuplicates = sacksWithCompartments.Select(x => SumOfDuplicates(x[0], x[1])).Sum();

Console.WriteLine($"Total sum of priorities of duplicates: {totalSumOfAllDuplicates}");
Console.ReadLine();

long SumOfDuplicates(string compartment1, string compartment2)
{
    return compartment1.ToCharArray().Intersect(compartment2.ToCharArray()).Select(x => _letterValues.IndexOf(x) + 1).Sum();
}