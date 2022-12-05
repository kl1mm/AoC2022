using System.Text.RegularExpressions;

namespace kli.AoC2022.Day_5;

[TestFixture]
public class Part2
{
    private static readonly Stack<char> oneSample = new(new List<char> {'Z', 'N'});
    private static readonly Stack<char> twoSample = new(new List<char> {'M', 'C', 'D'});
    private static readonly Stack<char> threeSample = new(new List<char> {'P'});

    private static readonly Stack<char> one = new(new List<char> {'B','W','N'});
    private static readonly Stack<char> two = new(new List<char> {'L','Z','S','P','T','D','M','B'});
    private static readonly Stack<char> three = new(new List<char> {'Q','H','Z','W','R'});
    private static readonly Stack<char> four = new(new List<char> {'W','D','V','J','Z','R'});
    private static readonly Stack<char> five = new(new List<char> {'S','H','M','B'});
    private static readonly Stack<char> six = new(new List<char> {'L','G','N','J','H','V','P','B' });
    private static readonly Stack<char> seven = new(new List<char> {'J','Q','Z','F','H','D','L','S'});
    private static readonly Stack<char> eight = new(new List<char> {'W','S','F','J','G','Q','B'});
    private static readonly Stack<char> nine = new(new List<char> {'Z', 'W', 'M','S','C','D','J'});

    private Stack<char>[] stacks = { one, two, three, four, five, six, seven, eight, nine };
    //private Stack<char>[] stacks = { oneSample, twoSample, threeSample };
    
    [Test]
    public async Task Test()
    {
        var inputLines = await File.ReadAllLinesAsync(Path.Combine("Day_5", "input.txt"));

        foreach (var line in inputLines)
        {
            var match = Regex.Match(line, "move (?<count>.*) from (?<from>.*) to (?<to>.*)");

            var count = int.Parse(match.Groups["count"].Value);
            var from = int.Parse(match.Groups["from"].Value);
            var to = int.Parse(match.Groups["to"].Value);

            var buffer = new List<char>();
            for (int i = 0; i < count; i++) buffer.Add(this.stacks[from - 1].Pop());
            buffer.Reverse();
            for (int i = 0; i < count; i++) this.stacks[to - 1].Push(buffer[i]);
        }

        var result = string.Join("", this.stacks.Select(stack => stack.Peek()));
        await TestContext.Out.WriteLineAsync($"The result is: {result}");
    }
}

