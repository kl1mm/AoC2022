namespace kli.AoC2022.Day_7;

[TestFixture]
public class Part2
{
    [Test]
    public async Task Test()
    {
        var inputLines = await File.ReadAllLinesAsync(Path.Combine("Day_7", "input.txt"));

        var currentDirectory = new Dir { Name = "root", Parent = null };
        var dirs = new HashSet<Dir> { currentDirectory };

        foreach (var line in inputLines.Skip(1))
        {
            if (line == "$ ls") { }
            else if (line[..3] == "dir") { }
            else if (line.Split('.').Length == 2)
                currentDirectory!.Files.Add(int.Parse(line.Split(' ')[0]));
            else if (line.Split(' ').Length == 2)
                currentDirectory!.Files.Add(int.Parse(line.Split(' ')[0]));
            else if (line[..4] == "$ cd")
            {
                var folderName = line.Split(" ")[2];
                if (folderName == "..")
                    currentDirectory = currentDirectory!.Parent;
                else
                {
                    var newDir = new Dir
                    {
                        Name = folderName,
                        Parent = currentDirectory
                    };
                    currentDirectory = newDir;
                    newDir.Parent!.Subs.Add(newDir);
                    dirs.Add(newDir);
                }
            }
        }

        var totalSize = dirs.Single(dir => dir.Parent == null).Size();
        var result = dirs.Select(dir => dir.Size())
            .OrderBy(x => x)
            .FirstOrDefault(size => (70_000_000 - totalSize) + size >= 30_000_000);

        await TestContext.Out.WriteLineAsync($"The result is: {result}");
    }

    public record Dir
    {
        public required string Name { get; init; }
        public required Dir? Parent { get; init; }
        public ICollection<Dir> Subs { get; } = new List<Dir>();
        public ICollection<int> Files { get; } = new List<int>();
        public int Size() => this.Subs.Sum(x => x.Size()) + this.Files.Sum();
    }
}