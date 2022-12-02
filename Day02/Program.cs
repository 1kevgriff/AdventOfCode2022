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
    var plays = new List<RPSPlay>();
    var line = string.Empty;

    while ((line = await reader.ReadLineAsync()) != null)
    {
        // process line
        plays.Add(new RPSPlay(line));
    }

    foreach (var play in plays)
    {
        Console.WriteLine(play);
    }

    Console.WriteLine("Total score: {0}", plays.Sum(p => p.Score));
}