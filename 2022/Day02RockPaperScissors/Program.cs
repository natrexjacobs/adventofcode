/* "What would your total score be if everything goes exactly according to your strategy guide?" */
/* input: input.txt */

internal partial class Program
{
  private static void Main(string[] args)
  {

    // break file into games
    var games = File.ReadAllText("input.txt")
      .Split("\r\n")
      .Select(line => new Game(line))
      .ToList();

    // debug: show all games
    games.ForEach(game => Console.WriteLine($"[{game.Input}] I {game.CalculateResult()} with {game.MyChoice} against {game.OpponentChoice} ({game.Score()} points)"));

    var total = games.Sum(game => game.Score());
    Console.WriteLine($"Total score: {total}");
  }
}
