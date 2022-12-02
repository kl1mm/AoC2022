namespace kli.AoC2022.Day_1;

[TestFixture]
public class Part1
{
    [Test]
    public async Task Test()
    {
        var input = await File.ReadAllTextAsync(Path.Combine("Day_1", "input.txt"));
        var result = input.Split("\r\n\r\n")
            .Select(g => g.Split("\r\n")
                .Sum(int.Parse))
            .Max();
        
        await TestContext.Out.WriteLineAsync($"The result is: {result}");
    }
}