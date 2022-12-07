Console.WriteLine("Welcome to the DAY 7!");
Console.WriteLine("");
Console.WriteLine("Started reading input...");
var inputText = await File.ReadAllLinesAsync(@"Input/input.txt");

var fileTree = new TreeNode("/", 0, true);
var currentDirectory = fileTree;

foreach (var line in inputText.Skip(1))
{
    var lineCharacters = line.Split(' ');
    if (lineCharacters[0] == "$")
    {
        if (lineCharacters[1] == "cd")
        {
            if (lineCharacters[2] == "..")
                currentDirectory = currentDirectory.Parent;
            else
            {
                currentDirectory = currentDirectory.FindInChildren(lineCharacters[2]);
            }
        }
        else if (lineCharacters[1] == "ls")
        {
        }
    }
    else
    {
        if (lineCharacters[0] == "dir")
        {
            currentDirectory.AddChild(lineCharacters[1], 0, true);
        }
        else
        {
            currentDirectory.AddChild(lineCharacters[1], long.Parse(lineCharacters[0]));
        }
    }
}

Console.WriteLine($"Sum of dirs under 100000 is {fileTree.TotalSumOfDirsUnder100000()}");
Console.ReadLine();


public class TreeNode
{
    private readonly string _name;
    private readonly long _size;
    private readonly bool _isDir;
    private readonly TreeNode _parent;
    private readonly List<TreeNode> _children;

    public TreeNode(string name, long size, bool isDir)
    {
        _name = name;
        _size = size;
        _isDir = isDir;
        _children = new List<TreeNode>();
    }

    public TreeNode(string name, long size, bool isDir, TreeNode parent) : this(name, size, isDir)
    {
        _parent = parent;
    }

    public int Count { get { return _children.Count; } }
    public bool IsRoot { get { return _parent == null; } }
    public string Name { get { return _name; } }
    public bool IsDir { get { return _isDir; } }
    public long Size { get { return _size != 0 ? _size : _children.Sum(x => x.Size); } }
    public TreeNode Parent { get { return _parent; } }
    public List<TreeNode> Children { get { return _children; } }

    public TreeNode this[int key]
    {
        get { return _children[key]; }
    }

    public TreeNode AddChild(string name, long size = 0, bool isDir = false)
    {
        TreeNode node = new TreeNode(name, size, isDir, this);
        _children.Add(node);

        return node;
    }

    public TreeNode FindInChildren(string name)
    {
        int i = 0, l = Count;
        for (; i < l; ++i)
        {
            TreeNode child = _children[i];
            if (child.Name.Equals(name)) return child;
        }

        return null;
    }

    public long TotalSumOfDirsUnder100000(long sum = 0)
    {
        int i = 0, l = Count;
        for (; i < l; ++i)
        {
            TreeNode child = _children[i];
            if (child.Children.Count > 0 && child.Size <= 100000) sum += child.Size;
            if (child.Children.Any(x => x.IsDir)) sum = child.TotalSumOfDirsUnder100000(sum);
        }
        return sum;
    }
}