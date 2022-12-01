namespace kli.AoC2022.Day_1;

[TestFixture]
public class Part2
{
    [Test]
    public async Task Part_1()
    {
        var input = await File.ReadAllTextAsync(Path.Combine("Day_1", "input.txt"));
        var result = input.Split("\r\n\r\n")
            .Select(g => g.Split("\r\n")
                .Sum(int.Parse))
            .OrderDescending()
            .Take(3)
            .Sum();
        
        await TestContext.Out.WriteLineAsync($"The result is: {result}");
    }
}