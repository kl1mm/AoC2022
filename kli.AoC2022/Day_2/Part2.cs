namespace kli.AoC2022.Day_2;

[TestFixture]
public class Part2 {

    [Test]
    public async Task Test()
    {
        var input = await File.ReadAllLinesAsync(Path.Combine("Day_2", "input.txt"));
        var result = input
            .Select(line => line.Split(' '))
            .Select(chars => new
            {
                oppChoice = CharToItem(chars.First()),
                result = CharToResult(chars.Last())
            })
            .Select(choices => PlayRound(choices.result, choices.oppChoice))
            .Sum();
        
        await TestContext.Out.WriteLineAsync($"The result is: {result}");
    }

    private Item CharToItem(string str)
    {
        return str[0] switch
        {
            'A' or 'X' => Item.Rock,
            'B' or 'Y' => Item.Paper,
            'C' or 'Z' => Item.Scissors,
            _ => throw new ArgumentOutOfRangeException(nameof(str))
        };
    } 
    
    private CompareResult CharToResult(string str)
    {
        return str[0] switch
        {
            'X' => CompareResult.Loss,
            'Y' => CompareResult.Draw,
            'Z' => CompareResult.Win,
            _ => throw new ArgumentOutOfRangeException(nameof(str))
        };
    }
    
    private int PlayRound(CompareResult result, Item opponentChoice)
    {
        var points = (int)result;
        points += (int)(result switch
        {
            CompareResult.Win when opponentChoice == Item.Rock => Item.Paper,
            CompareResult.Win when opponentChoice == Item.Paper => Item.Scissors,
            CompareResult.Win when opponentChoice == Item.Scissors => Item.Rock,
            CompareResult.Loss when opponentChoice == Item.Rock => Item.Scissors,
            CompareResult.Loss when opponentChoice == Item.Paper => Item.Rock,
            CompareResult.Loss when opponentChoice == Item.Scissors => Item.Paper,
            CompareResult.Draw => opponentChoice,
            _ => throw new ArgumentOutOfRangeException(nameof(result), result, null)
        });
        
        return points;
    }

    public enum CompareResult { Loss = 0, Draw = 3, Win = 6 }
    public enum Item { Rock = 1, Paper = 2, Scissors = 3 }    
}
