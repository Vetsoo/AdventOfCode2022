Console.WriteLine("Welcome to the DAY 9!");
Console.WriteLine("");
Console.WriteLine("Started reading input...");
var inputText = await File.ReadAllLinesAsync(@"Input/input.txt");

var tailVisited = new List<Tuple<int,int>>() { new Tuple<int,int>(0, 0) };
var tailPosition = new Tuple<int, int>(0, 0);
var headPosition = new Tuple<int,int>(0, 0);

foreach (var instruction in inputText)
{
    var direction = instruction[0];
    var numberOfSteps = instruction[2] - '0';
    for (int i = 1; i <= numberOfSteps; i++)
    {
        switch (direction)
        {
            case 'R':
                headPosition = new Tuple<int, int>(headPosition.Item1, headPosition.Item2 + 1);
                CalculateTailPosition(0, 1);
                break;
            case 'D':
                headPosition = new Tuple<int, int>(headPosition.Item1 + 1, headPosition.Item2);
                CalculateTailPosition(1, 0);
                break;
            case 'L':
                headPosition = new Tuple<int, int>(headPosition.Item1, headPosition.Item2 - 1);
                CalculateTailPosition(0, -1);
                break;
            case 'U':
                headPosition = new Tuple<int, int>(headPosition.Item1 - 1, headPosition.Item2);
                CalculateTailPosition(-1, 0);
                break;
            default:
                break;
        }
    }
}

void CalculateTailPosition(int row, int col)
{
    if (headPosition.Item1 - tailPosition.Item1 > 1 ||
    headPosition.Item2 - tailPosition.Item2 > 1)
    {
        tailPosition = new Tuple<int, int>(tailPosition.Item1 + row, tailPosition.Item2 + col);
    }
}

Console.ReadLine();