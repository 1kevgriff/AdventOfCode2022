public class Elf {
    public List<int> CaloriesCarried {get;set;} = new();

    public int TotalCalories => CaloriesCarried.Sum();
}