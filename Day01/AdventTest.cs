
using Xunit;

public class AdventTest
{
    [Fact]
    public async Task Sample()
    {
        var expected = 24000;

        // get sample file
        var sampleFile = Path.Combine(Directory.GetCurrentDirectory(), "../../../sample.txt");

        var adventRunner = new Advent(sampleFile);
        var actual = await adventRunner.TotalCaloriesTop();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task Data1()
    {
        var expected = 70764;

        // get sample file
        var sampleFile = Path.Combine(Directory.GetCurrentDirectory(), "../../../data1.txt");

        var adventRunner = new Advent(sampleFile);
        var actual = await adventRunner.TotalCaloriesTop();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task Data2()
    {
        var expected = 203905;

        // get sample file
        var sampleFile = Path.Combine(Directory.GetCurrentDirectory(), "../../../data2.txt");

        var adventRunner = new Advent(sampleFile);
        var actual = await adventRunner.TotalCaloriesTop3();

        Assert.Equal(expected, actual);
    }
}