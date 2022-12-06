Console.WriteLine("Welcome to the DAY 6!");
Console.WriteLine("");
Console.WriteLine("Started reading input...");
var inputText = await File.ReadAllLinesAsync(@"Input/input.txt");

var positionOfStartOfPacketMarker = inputText
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

var positionOfStartOfMessageMarker = inputText
    .Select(x => x.ToCharArray())
    .Select(x =>
    {
        for (int j = 13; j < x.Length; j++)
        {
            var previousArray = new char[14];
            Array.Copy(x, j - 13, previousArray, 0, 14);
            var duplicate = previousArray.GroupBy(x => x).Any(g => g.Count() > 1);

            if (!duplicate)
            {
                return j + 1;
            }
        }

        return 0;
    });

foreach (var position in positionOfStartOfPacketMarker)
{
    Console.WriteLine($"Position of marker: {position}");
}
foreach (var position in positionOfStartOfMessageMarker)
{
    Console.WriteLine($"Position of marker: {position}");
}
Console.ReadLine();