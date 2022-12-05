// A & X = Rock = 1
// B & Y = Paper = 2
// C & Z = Scissors = 3
// Win = 6
// Draw = 3
// Lose = 0

// X = Lose
// Y = Draw
// Z = Win

Console.WriteLine("Welcome to the DAY 2!");
Console.WriteLine("");
Console.WriteLine("Started reading input...");
var inputText = await File.ReadAllLinesAsync(@"Input/input.txt");

var totalPointsForMovesStep1 = inputText.Select(x => ScoreForMoveStep1(x.Split(' ')[1])).Sum();
var totalPointsForGamesStep1 = inputText.Select(x => ScoreForGameStep1(x.Split(' ')[0], x.Split(' ')[1])).Sum();

Console.WriteLine($"Total points step 1: {totalPointsForMovesStep1 + totalPointsForGamesStep1}");

var totalPointsForGamesStep2 = inputText.Select(x => ScoreForGameStep2(x.Split(' ')[1])).Sum();
var totalPointsForMovesStep2 = inputText.Select(x => ScoreForMoveStep2(x.Split(' ')[0], x.Split(' ')[1])).Sum();

Console.WriteLine($"Total points step 2: {totalPointsForMovesStep2 + totalPointsForGamesStep2}");

Console.ReadLine();

long ScoreForMoveStep1(string move)
{
    return move switch
    {
        "X" => 1,
        "Y" => 2,
        "Z" => 3,
        _ => 0,
    };
}

long ScoreForGameStep1(string opponentMove, string move)
{
    return (opponentMove, move) switch
    {
        ("A", "X") => 3,
        ("A", "Y") => 6,
        ("B", "Y") => 3,
        ("B", "Z") => 6,
        ("C", "X") => 6,
        ("C", "Z") => 3,
        _ => 0,
    };
}

long ScoreForMoveStep2(string opponentMove, string result)
{
    return (opponentMove, result) switch
    {
        ("A", "X") => 3,
        ("A", "Y") => 1,
        ("A", "Z") => 2,
        ("B", "X") => 1,
        ("B", "Y") => 2,
        ("B", "Z") => 3,
        ("C", "X") => 2,
        ("C", "Y") => 3,
        ("C", "Z") => 1,
        _ => 0,
    };
}

long ScoreForGameStep2(string result)
{
    return result switch
    {
        "Y" => 3,
        "Z" => 6,
        _ => 0,
    };
}
