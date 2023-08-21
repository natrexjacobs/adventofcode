/* input.txt - elf calorie list, one per line, blank line separated */

PartOne();
PartTwo();

void PartOne()
{
  /* Part 1: how many Calories are being carried by the Elf carrying the most Calories? */

  // get all data from file
  var data = File.ReadAllText("input.txt");

  // break by empty lines
  var chunkPerElf = data.Split("\r\n\r\n");

  // prase each chunk into numeric values
  var valuesByElf = chunkPerElf.Select(chunk => chunk.Split("\r\n").Select(value => int.Parse(value)));

  // find elf with the most calories
  var maxElf = valuesByElf.Max(values => values.Sum());

  Console.WriteLine($"Part 1 Answer: {maxElf} (most calories carried by an elf)");
  // Result: The most calories carried by an elf is 71934
}

void PartTwo()
{
  /* Part 2: the Elves would instead like to know the total Calories carried by the top three Elves carrying the most Calories */

  // get all data from file
  var elves = File.ReadAllText("input.txt")
    // split into per elf chunks (on empty line)
    .Split("\r\n\r\n")
    // parse values (per line)
    .Select(chunk => chunk.Split("\r\n").Select(value => int.Parse(value)))
    // sum values per elf (and include elf index)
    .Select((values, elfIndex) => new KeyValuePair<int, int>(elfIndex, values.Sum()))
    // most calories first
    .OrderByDescending(elf => elf.Value)
    .ToList();

  // for interest sake
  // elves.ForEach(elf => Console.WriteLine($"Elf {elf.Key}: {elf.Value}"));

  // answer
  var answer = elves.Take(3).Sum(elf => elf.Value);
  Console.WriteLine($"Part 2 Answer: {answer} (total calories carried by top 3 elves)");
}

