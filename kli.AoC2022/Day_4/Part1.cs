namespace kli.AoC2022.Day_4;

[TestFixture]
public class Part1
{
    [Test]
    public async Task Test()
    {
        var inputLines = await File.ReadAllLinesAsync(Path.Combine("Day_4", "input.txt"));

        HashSet<int> ToSet(int start, int end) => new(Enumerable.Range(start, end - start +1));

        bool IsSubset(string line)
        {
            var left = line.Split(',').First();
            var right = line.Split(',').Last();

            var leftSet = ToSet(int.Parse(left.Split('-').First()), int.Parse(left.Split('-').Last()));
            var rightSet = ToSet(int.Parse(right.Split('-').First()), int.Parse(right.Split('-').Last()));

            return leftSet.IsSubsetOf(rightSet) || rightSet.IsSubsetOf(leftSet);
        }
        
        var result = inputLines.Where(IsSubset).Count();
        
        await TestContext.Out.WriteLineAsync($"The result is: {result}");
    }
}

