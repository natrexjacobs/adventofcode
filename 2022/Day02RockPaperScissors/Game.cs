/* input: input.txt */
using Day02RockPaperScissors;
using Day02RockPaperScissors.Enum;

public class Game
{
  // The score for a single round is the score for the shape you selected
  // - 1 for Rock
  // - 2 for Paper
  // - 3 for Scissors
  // opponent :  A for Rock, B for Paper, and C for Scissors.
  // you: X for Rock, Y for Paper, and Z for Scissors. 
  private Dictionary<Choice, int> _ruleChoiceScores = new Dictionary<Choice, int>{
      {Choice.Rock, 1},
      { Choice.Paper, 2},
      { Choice.Scissors, 3},
    };

  // plus the score for the outcome of the round 
  // - 0 if you lost
  // - 3 if the round was a draw
  // - 6 if you won
  private Dictionary<Result, int> _ruleResultScore = new Dictionary<Result, int>{
      {Result.Lost, 0},
      {Result.Draw, 3},
      {Result.Win, 6},
    };

  public string Input { get; init; }
  public Choice MyChoice { get; init; }
  public Choice OpponentChoice { get; init; }

  public Game(string input)
  {
    Input = input;
    var choices = input.Split(" ");
    OpponentChoice = Parser.OpponentChoice(choices[0]);
    MyChoice = Parser.MyChoice(choices[1]);
  }

  // get game score
  public int Score()
  {
    // figure out who wins
    var result = CalculateResult();

    // score
    var choiceScore = _ruleChoiceScores[MyChoice];
    var resultScore = _ruleResultScore[result];
    return choiceScore + resultScore;
  }

  // return game result
  public Result CalculateResult()
  {
    if (MyChoice == OpponentChoice)
      return Result.Draw;

    // rock loss
    if (MyChoice == Choice.Rock && OpponentChoice == Choice.Paper)
      return Result.Lost;

    // paper loss
    if (MyChoice == Choice.Paper && OpponentChoice == Choice.Scissors)
      return Result.Lost;

    // scissors loss
    if (MyChoice == Choice.Scissors && OpponentChoice == Choice.Rock)
      return Result.Lost;

    // everything else is win baby!
    return Result.Win;
  }

  public Choice CalculatePlay(Choice opponentChoice, Result desiredResult)
  {
    // TODO:
    // X means you need to lose, 
    // Y means you need to end the round in a draw, 
    // Z means you need to win.
  }
}
