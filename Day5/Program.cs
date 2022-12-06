Console.WriteLine("Welcome to the DAY 5!");
Console.WriteLine("");
Console.WriteLine("Started reading input...");
var inputText = await File.ReadAllTextAsync(@"Input/input.txt");

var stacks = GetStacks(inputText.Split("\r\n\r\n").First());
var newStacks = GetStacks(inputText.Split("\r\n\r\n").First());
var instructions = GetInstructions(inputText.Split("\r\n\r\n").Last());

foreach (var instruction in instructions)
{
    for (var i = 0; i < instruction.Item1; i++)
    {
        var value = stacks[instruction.Item2 - 1].Pop();
        stacks[instruction.Item3 - 1].Push(value);
    }
}

foreach (var instruction in instructions)
{
    var newStack = new Stack<char>();
    for (var i = 0; i < instruction.Item1; i++)
    {
        var value = newStacks[instruction.Item2 - 1].Pop();
        newStack.Push(value);
    }

    for (var i = 0; newStack.Count > 0; i++)
    {
        var value = newStack.Pop();
        newStacks[instruction.Item3 - 1].Push(value);
    }
}

var result = GetTopOfStacks(stacks);
var result9100 = GetTopOfStacks(newStacks);

Console.WriteLine($"End result CrateMover9000: {result}");
Console.WriteLine($"End result CrateMover9001: {result9100}");
Console.ReadLine();

static Stack<char>[] GetStacks(string stacksAsString)
{
    var splittedStringReversed = stacksAsString.Split("\r\n").Reverse();
    var stacks = new Stack<char>[splittedStringReversed.First().Replace(" ", "").Length].Select(x => new Stack<char>()).ToArray();

    foreach (var item in splittedStringReversed.Skip(1))
    {
        var counter = 0;
        for (var i = 1; i < item.Length; i += 4)
        {
            if (item[i] != ' ')
                stacks[counter].Push(item[i]);
            counter++;
        }
    }

    return stacks;
}

static Tuple<int, int, int>[] GetInstructions(string instructionsAsString)
{
    return instructionsAsString
        .Split("\r\n")
        .Select(x =>
        {
            var split = x.Split(' ').ToArray();
            return new Tuple<int, int, int>(int.Parse(split[1]), int.Parse(split[3]), int.Parse(split[5]));
        })
        .ToArray();
}

static string GetTopOfStacks(Stack<char>[] stacks)
{
    var result = "";
    foreach (var stack in stacks)
    {
        if (stack.Count > 0)
            result += stack.Peek();
    }

    return result.Replace(" ", "").Trim();
}

