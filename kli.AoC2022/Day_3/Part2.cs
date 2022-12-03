namespace kli.AoC2022.Day_3;

[TestFixture]
public class Part2
{
    [Test]
    public async Task Test()
    {
        int FindItem(string one, string two, string three)
        {
            foreach (var item in one)
            {
                if (two.Contains(item, StringComparison.Ordinal) && three.Contains(item, StringComparison.Ordinal))
                    return item - (char.IsLower(item) ? 97 : 65 - 26) + 1;
            }

            throw new Exception();
        }

        var result = 0;
        var inputLines = await File.ReadAllLinesAsync(Path.Combine("Day_3", "input.txt"));
        for (int i = 0; i < inputLines.Length; i += 3)
        {
            var one = inputLines[i];
            var two = inputLines[i+1];
            var three = inputLines[i+2];

            result += FindItem(one, two, three);
        }

        await TestContext.Out.WriteLineAsync($"The result is: {result}");
    }
}

