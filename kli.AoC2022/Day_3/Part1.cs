namespace kli.AoC2022.Day_3;

[TestFixture]
public class Part1
{
    [Test]
    public async Task Test()
    {
        var inputLines = await File.ReadAllLinesAsync(Path.Combine("Day_3", "input.txt"));

        int FindItem(string s)
        {
            var head = s[..(s.Length / 2)];
            var tail = s[(s.Length / 2)..];
            foreach (var charFront in head.ToArray())
            {
                foreach (var charEnd in tail.Reverse().ToArray())
                {
                    if (charFront.Equals(charEnd))
                        return charFront - (char.IsLower(charFront) ? 97 : 65-26) + 1;
                }
            }

            throw new NotSupportedException();
        }

        var result = inputLines.Sum(FindItem);
        
        await TestContext.Out.WriteLineAsync($"The result is: {result}");
    }
}

