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

var adventRunner = new Advent(inputFile);
adventRunner.TotalCaloriesTop3();