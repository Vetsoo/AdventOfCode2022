Console.WriteLine("Welcome to the DAY 6!");
Console.WriteLine("");
Console.WriteLine("Started reading input...");
var inputText = await File.ReadAllLinesAsync(@"Input/input.txt");

var positionOfMarker = inputText
    .Select(x => x.ToCharArray())
    .Select(x =>
    {
        for (int j = 3; j < x.Length; j++)
        {
            var previousArray = new char[4] { x[j - 3], x[j - 2], x[j - 1], x[j] };
            var duplicate = previousArray.GroupBy(x => x).Any(g => g.Count() > 1);

            if (!duplicate)
            {
                return j + 1;
            }
        }

        return 0;
    });

foreach (var position in positionOfMarker)
{
    Console.WriteLine($"Position of marker: {position}");
}
Console.ReadLine();