// A & X = Rock = 1
// B & Y = Paper = 2
// C & Z = Scissors = 3
// Win = 6
// Draw = 3
// Lose = 0

Console.WriteLine("Welcome to the DAY 2!");
Console.WriteLine("");
Console.WriteLine("Started reading input...");
var inputText = await File.ReadAllLinesAsync(@"Input/input.txt");

var totalPointsForMoves = inputText.Select(x => ScoreForMove(x.Split(' ')[1])).Sum();
var totalPointsForGames = inputText.Select(x => ScoreForGame(x.Split(' ')[0], x.Split(' ')[1])).Sum();

Console.WriteLine($"Total points: {totalPointsForMoves + totalPointsForGames}");
Console.ReadLine();

long ScoreForMove(string move)
{
    switch (move)
    {
        case "X": return 1;
        case "Y": return 2;
        case "Z": return 3;
        default: return 0;
    }
}

long ScoreForGame(string opponentMove, string move)
{
    switch (opponentMove, move)
    {
        case ("A", "X"): return 3;
        case ("A", "Y"): return 6;
        case ("A", "Z"): return 0;
        case ("B", "X"): return 0;
        case ("B", "Y"): return 3;
        case ("B", "Z"): return 6;
        case ("C", "X"): return 6;
        case ("C", "Y"): return 0;
        case ("C", "Z"): return 3;
        default: return 0;
    }
}