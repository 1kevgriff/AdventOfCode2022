public class Rucksack
{
    public Rucksack(string input)
    {
        // divide input string into half
        var partOne = input.Substring(0, input.Length / 2);
        var partTwo = input.Substring(input.Length / 2);

        Console.WriteLine($"Part One: {partOne} ~ Part Two: {partTwo}");

        foreach (var c in partOne)
        {
            var key = $"{c}";
            if (CompartmentOne.ContainsKey(key))
            {
                CompartmentOne[key]++;
            }
            else
            {
                CompartmentOne.Add(key, 1);
            }
        }

        foreach(var c in partTwo)
        {
            var key = $"{c}";
            if (CompartmentTwo.ContainsKey(key))
            {
                CompartmentTwo[key]++;
            }
            else
            {
                CompartmentTwo.Add(key, 1);
            }
        }
    }

    private static string Priorities = "!abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public static int Priority(char key) => Priorities.IndexOf(key);

    private Dictionary<string, int> CompartmentOne { get; set; } = new();
    private Dictionary<string, int> CompartmentTwo { get; set; } = new();

    public string UniqueItems => string.Join("", CompartmentOne.Keys.Union(CompartmentTwo.Keys).OrderBy(k => Priority(k[0])));

    public string InBoth => string.Join("", CompartmentOne.Keys.Intersect(CompartmentTwo.Keys));
    public int InBothPriority => InBoth.Sum(c => Priorities.IndexOf(c));

    // public string UniqueItems => string.Join("", CompartmentOne.Keys.Distinct().OrderBy(c => Priorities.IndexOf(c)));
    // public int Score => UniqueItems.Select(p => Priorities.IndexOf(p)).Sum();
}