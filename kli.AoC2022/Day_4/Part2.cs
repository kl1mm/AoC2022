namespace kli.AoC2022.Day_4;

[TestFixture]
public class Part2
{
    [Test]
    public async Task Test()
    {
        var inputLines = await File.ReadAllLinesAsync(Path.Combine("Day_4", "input.txt"));

        HashSet<int> ToSet(int start, int end) => new(Enumerable.Range(start, end - start +1));

        bool Overlaps(string line)
        {
            var left = line.Split(',').First();
            var right = line.Split(',').Last();

            var leftSet = ToSet(int.Parse(left.Split('-').First()), int.Parse(left.Split('-').Last()));
            var rightSet = ToSet(int.Parse(right.Split('-').First()), int.Parse(right.Split('-').Last()));

            return leftSet.Overlaps(rightSet);
        }
        
        var result = inputLines.Where(Overlaps).Count();
        
        await TestContext.Out.WriteLineAsync($"The result is: {result}");
    }
}

