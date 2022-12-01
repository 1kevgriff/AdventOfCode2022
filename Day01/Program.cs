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

var elfs = new List<Elf>();

// open file for reading
using (var reader = new StreamReader(inputFile))
{
    // read file line by line
    string line;

    elfs.Add(new Elf());

    while ((line = await reader.ReadLineAsync()) != null)
    {
        // process line
        if (string.IsNullOrWhiteSpace(line))
        {
            elfs.Add(new Elf());
            continue;
        }

        elfs.Last().CaloriesCarried.Add(int.Parse(line));
        Console.WriteLine("Elf {0} has {1} calories", elfs.Count, line);
    }

    Console.WriteLine("---");
    // find top 3 elves
    var top3 = elfs.OrderByDescending(e => e.TotalCalories).Take(3);
    for (int i = 0; i < top3.Count(); i++)
    {
        Console.WriteLine("{2}. Elf {0} has {1} calories", i + 1, top3.ElementAt(i).TotalCalories, i);
    }
    Console.WriteLine("Total: {0}", top3.Sum(e => e.TotalCalories));
}