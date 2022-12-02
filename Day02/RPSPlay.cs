public class RPSPlay
{
    public RPSPlay(string play)
    {
        Console.WriteLine("Reading play: {0}", play);
        
        var split = play.Split(' ');
        if (split[0] == "A") Opponent = RPS.Rock;
        else if (split[0] == "B") Opponent = RPS.Paper;
        else if (split[0] == "C") Opponent = RPS.Scissors;
        else throw new ArgumentException("Invalid opponent");

        Mine = IdealChoice(Opponent, split[1]);

        Console.WriteLine("Opponent: {0} | Me: {1} === {2}", Opponent, Mine, DidIWin);
    }

    private RPS IdealChoice(RPS opponent, string choice){
        // X == I need to lose
        // Y == I need to draw
        // Z == I need to win
        if (choice.Equals("Y")) return opponent;
        if (choice.Equals("X") && opponent == RPS.Rock) return RPS.Scissors;
        if (choice.Equals("X") && opponent == RPS.Paper) return RPS.Rock;
        if (choice.Equals("X") && opponent == RPS.Scissors) return RPS.Paper;
        if (choice.Equals("Z") && opponent == RPS.Rock) return RPS.Paper;
        if (choice.Equals("Z") && opponent == RPS.Paper) return RPS.Scissors;
        if (choice.Equals("Z") && opponent == RPS.Scissors) return RPS.Rock;

        throw new Exception("Invalid choice");
    }

    public RPS Opponent { get; set; }
    public RPS Mine { get; set; }

    public bool DidIWin {
        get {
            if (Opponent == Mine) return false;
            if (Opponent == RPS.Rock && Mine == RPS.Paper) return true;
            if (Opponent == RPS.Paper && Mine == RPS.Scissors) return true;
            if (Opponent == RPS.Scissors && Mine == RPS.Rock) return true;
            return false;
        }
    }

    public bool DidIDraw => Opponent == Mine;

    public int Score
    {
        get
        {
            if (DidIDraw) return (int)DrawWinLose.Draw + (int)Mine;
            if (DidIWin) return (int)(Mine) + (int)DrawWinLose.Win;
            return (int)Mine;
        }
    }

    public override string ToString()
    {
        return $"Opponent: {Opponent} | Me: {Mine} === {DidIWin} | Score: {Score}";
    }
}

public enum RPS
{
    Rock = 1,
    Paper = 2,
    Scissors = 3
}

public enum DrawWinLose
{
    Draw = 3,
    Win = 6,
    Lose = 0
}