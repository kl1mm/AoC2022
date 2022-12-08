namespace kli.AoC2022.Day_8;

[TestFixture]
public class Part2
{
    [Test]
    public async Task Test()
    {
        var inputLines = await File.ReadAllLinesAsync(Path.Combine("Day_8", "input.txt"));
        
        var trees = new List<List<int>>();
        foreach (string line in inputLines)
            trees.Add(line.Select(x => x - '0').ToList());

        var result = -1;
        for (int i = 0; i < trees.Count; i++)
        {
            for (int j = 0; j < trees[i].Count; j++)
            {
                var upCount = 0;
                for (int u = i - 1; u >= 0; u--)
                {
                    upCount++;
                    if (trees[i][j] <= trees[u][j]) break;
                }
                var downCount = 0;
                for (int d = i + 1; d < trees.Count; d++)
                {
                    downCount++;
                    if (trees[i][j] <= trees[d][j]) break;
                }
                var leftCount = 0;
                for (int l = j - 1; l >= 0; l--)
                {
                    leftCount++;
                    if (trees[i][j] <= trees[i][l]) break;
                }
                var rightCount = 0;
                for (int r = j + 1; r < trees[i].Count; r++)
                {
                    rightCount++;
                    if (trees[i][j] <= trees[i][r]) break;
                }

                result = Math.Max(result, upCount * downCount * leftCount * rightCount);
            }
        }
        await TestContext.Out.WriteLineAsync($"The result is: {result}");
    }
}