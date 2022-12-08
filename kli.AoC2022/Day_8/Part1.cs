namespace kli.AoC2022.Day_8;

[TestFixture]
public class Part1
{
    [Test]
    public async Task Test()
    {
        var inputLines = await File.ReadAllLinesAsync(Path.Combine("Day_8", "input.txt"));

        List<List<int>> trees = inputLines.Select(line => line.Select(chr => chr - '0').ToList()).ToList();

        int result = 0;
        for (int i = 0; i < trees.Count; i++)
        {
            for (int j = 0; j < trees.Count; j++)
            {
                if (trees.Select(t => t[j]).Take(i).All(t => t < trees[i][j])) { result++; continue; }
                if (trees.Select(t => t[j]).Skip(i + 1).All(t => t < trees[i][j])) { result++; continue; }
                if (trees[i].Take(j).All(t => t < trees[i][j])) { result++; continue; } 
                if (trees[i].Skip(j + 1).All(t => t < trees[i][j])) { result++; }
            }
        }
        
        await TestContext.Out.WriteLineAsync($"The result is: {result}");
    }
}