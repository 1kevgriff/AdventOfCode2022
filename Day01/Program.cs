var inputFile = "sample.txt";

var elfs = new List<Elf>();

// open file for reading
using (var reader = new StreamReader(inputFile))
{
    // read file line by line
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        // process line

    }
}