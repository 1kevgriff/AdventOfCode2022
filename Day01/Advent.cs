public class Advent
{
    public Advent(string inputFile)
    {
        InputFile = inputFile;
    }

    public string InputFile { get; }

    internal async Task<int> TotalCaloriesTop()
    {
        var elfs = new List<Elf>();

        // open file for reading
        using (var reader = new StreamReader(InputFile))
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
            // find top elves
            var top = elfs.Max(p=> p.TotalCalories);

            return top;
        }
    }

    internal async Task<int> TotalCaloriesTop3()
    {
        var elfs = new List<Elf>();

        // open file for reading
        using (var reader = new StreamReader(InputFile))
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
            // find top elves
            var top = elfs.OrderByDescending(p=> p.TotalCalories).Take(3);

            return top.Sum(p=> p.TotalCalories);
        }
    }
}