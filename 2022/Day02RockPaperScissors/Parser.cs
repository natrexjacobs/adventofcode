using Day02RockPaperScissors.Enum;

namespace Day02RockPaperScissors;

public static class Parser
{
  public static Choice OpponentChoice(string value) => value switch
  {
    "A" => Choice.Rock,
    "B" => Choice.Paper,
    "C" => Choice.Scissors,
    _ => throw new Exception($"Invalid input, must be A, B or C (not {value})")
  };

  public static Choice MyChoice(string value) => value switch
  {
    "X" => Choice.Rock,
    "Y" => Choice.Paper,
    "Z" => Choice.Scissors,
    _ => throw new Exception($"Invalid input, must be X, Y or Z (not {value})")
  };
}
