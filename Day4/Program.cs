Console.WriteLine("Welcome to the DAY 4!");
Console.WriteLine("");
Console.WriteLine("Started reading input...");
var inputText = await File.ReadAllLinesAsync(@"Input/input.txt");

var totalCompleteOverlaps = inputText
    .Select(x => x.Split(',').SelectMany(y => y.Split('-').Select(int.Parse)).ToArray())
    .Select(x => DoSectionsOverlapCompletely(x[0], x[1], x[2], x[3]))
    .Sum();

var totalOverlaps = inputText
    .Select(x => x.Split(',').SelectMany(y => y.Split('-').Select(int.Parse)).ToArray())
    .Select(x => DoSectionsOverlap(x[0], x[1], x[2], x[3]))
    .Sum();

Console.WriteLine($"Total complete overlaps: {totalCompleteOverlaps}");
Console.WriteLine($"Total overlaps: {totalOverlaps}");
Console.ReadLine();

static long DoSectionsOverlapCompletely(int elf1Start, int elf1Stop, int elf2Start, int elf2Stop)
{
    var elf1Range = Enumerable.Range(elf1Start, elf1Stop - elf1Start + 1);
    var elf2Range = Enumerable.Range(elf2Start, elf2Stop - elf2Start + 1);
    var overlap = elf1Range.Intersect(elf2Range);
    if (Enumerable.SequenceEqual(overlap, elf1Range) || Enumerable.SequenceEqual(overlap, elf2Range))
        return 1;
    return 0;
}

static long DoSectionsOverlap(int elf1Start, int elf1Stop, int elf2Start, int elf2Stop)
{
    var elf1Range = Enumerable.Range(elf1Start, elf1Stop - elf1Start + 1);
    var elf2Range = Enumerable.Range(elf2Start, elf2Stop - elf2Start + 1);
    var overlap = elf1Range.Intersect(elf2Range);
    if (overlap.Any())
        return 1;
    return 0;
}