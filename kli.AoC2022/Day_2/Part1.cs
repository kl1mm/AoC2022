namespace kli.AoC2022.Day_2;

[TestFixture]
public class Part1
{
    [Test]
    public async Task Test()
    {
        var input = await File.ReadAllLinesAsync(Path.Combine("Day_2", "input.txt"));
        var result = input
            .Select(line => line.Split(' '))
            .Select(chars => new
            {
                oppChoice = CharToItem(chars.First()),
                myChoice = CharToItem(chars.Last())
            })
            .Select(choices => PlayRound(choices.myChoice, choices.oppChoice))
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
    
    private int PlayRound(Item myChoice, Item opponentChoice)
    {
        var points = (int)myChoice;
        if (myChoice == opponentChoice)
            points += (int)CompareResult.Draw;

        points +=(int)(myChoice switch
        {
            Item.Rock when opponentChoice == Item.Scissors => CompareResult.Win,
            Item.Paper when opponentChoice == Item.Rock => CompareResult.Win,
            Item.Scissors when opponentChoice == Item.Paper => CompareResult.Win,
            _ => CompareResult.Loss
        });

        return points;
    }

    public enum CompareResult { Loss = 0, Draw = 3, Win = 6 }
    public enum Item { Rock = 1, Paper = 2, Scissors = 3 }
}

