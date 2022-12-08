Console.WriteLine("Welcome to the DAY 8!");
Console.WriteLine("");
Console.WriteLine("Started reading input...");
var inputText = await File.ReadAllLinesAsync(@"Input/input.txt");

var forestMap = new int[inputText.Length, inputText.First().Length];
var visibleTrees = new List<Tuple<int, int>>();

for (int row = 0; row < inputText.Length; row++)
{
    for (int col = 0; col < inputText[row].Length; col++)
    {
        forestMap[row, col] = inputText[row][col] - '0';
    }
}

for (var row = 0; row < inputText.Length; row++)
{
    for (int col = 0, leftHighestTree = -1, rightHighestTree = -1, topHighestTree = -1, bottomHighestTree = -1; col < inputText.First().Length; col++)
    {
        if (forestMap[row, col] > leftHighestTree)
        {
            leftHighestTree = forestMap[row, col];
            visibleTrees.Add(new Tuple<int, int>(row, col));
        }

        var rightCol = forestMap.GetLength(1) - 1 - col;
        if (forestMap[row, rightCol] > rightHighestTree)
        {
            rightHighestTree = forestMap[row, rightCol];
            visibleTrees.Add(new Tuple<int, int>(row, rightCol));
        }

        if (forestMap[col, row] > topHighestTree)
        {
            topHighestTree = forestMap[col, row];
            visibleTrees.Add(new Tuple<int, int>(col, row));
        }

        var rowBottom = forestMap.GetLength(0) - 1 - col;
        if (forestMap[rowBottom, row] > bottomHighestTree)
        {
            bottomHighestTree = forestMap[rowBottom, row];
            visibleTrees.Add(new Tuple<int, int>(rowBottom, row));
        }
    }
}

Console.WriteLine($"Amount of visible trees: {visibleTrees.Distinct().Count()}");
Console.ReadLine();