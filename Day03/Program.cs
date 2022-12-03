var inputFile = string.Empty;

if (args.Length > 0)
{
    inputFile = args[0];
}

if (string.IsNullOrEmpty(inputFile))
{
    Console.WriteLine("Please specify a file to process.");
    return;
}

// open file for reading
using (var reader = new StreamReader(inputFile))
{
    var line = string.Empty;
    var rucksacks = new List<Rucksack>();

    while ((line = await reader.ReadLineAsync()) != null)
    {
        Console.WriteLine($"Ttems: {line}");
        rucksacks.Add(new Rucksack(line));

        Console.WriteLine("In both: {0} ({1})", rucksacks.Last().InBoth, rucksacks.Last().InBothPriority);
        Console.WriteLine();
    }

    Console.WriteLine("Total score: {0}", rucksacks.Sum(r => r.InBothPriority));

    var groupScores = 0;
    for (int x = 0; x < rucksacks.Count; x += 3)
    {
        // fimd match in x, x+1, x+2
        var match = rucksacks[x].UniqueItems.Intersect(rucksacks[x + 1].UniqueItems).Intersect(rucksacks[x + 2].UniqueItems);
        groupScores += Rucksack.Priority(match.First());
        Console.WriteLine("Group {0}-{1}: {2} ({3})", x, x + 2, string.Join("", match), Rucksack.Priority(match.First()));
    }

    Console.WriteLine("Total Score: {0}", groupScores);
}