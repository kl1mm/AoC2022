namespace kli.AoC2022.Day_6;

[TestFixture]
public class Part2
{
    [Test]
    public async Task Test()
    {
        var inputLine = await File.ReadAllTextAsync(Path.Combine("Day_6", "input.txt"));
        
        var result = 0;
        for (int i = 0; i < inputLine.Length; i++)
        {
            if (inputLine[i..].Take(14).Distinct().Count() == 14)
            {
                result = i + 14;
                break;
            }
        }        

        await TestContext.Out.WriteLineAsync($"The result is: {result}");
    }
}

