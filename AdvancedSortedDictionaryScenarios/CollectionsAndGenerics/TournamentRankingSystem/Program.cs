
public class Team : IComparable<Team>
{
    public string Name { get; set; }
    public int Points { get; set; }
    
    public int CompareTo(Team other)
    {
        // TODO: Compare by points descending, then by name
        
        int pointCmp= other.Points.CompareTo(this.Points);
        if(pointCmp!=0) return pointCmp;
        return this.Name.CompareTo(other.Name);
    }
}

public class Match
{
    public Team T1{get; }
    public Team T2{get; }
    public int Team1Score {get; set;}
    public int Team2Score {get; set;}

    public Match(Team teamA,Team teamB)
    {
        this.T1=teamA;
        this.T2=teamB;   
    }   

    public Match Clone()
    {
        return new Match(T1, T2)
        {
          Team1Score=this.Team1Score,
          Team2Score=this.Team2Score  
        };
    }
}
public class Tournament
{
    private SortedList<int, Team> _rankings = new SortedList<int, Team>();
    private LinkedList<Match> _schedule = new LinkedList<Match>();
    private Stack<Match> _undoStack = new Stack<Match>();
    
    // Add match to schedule
    public void ScheduleMatch(Match match)
    {
        // TODO: Add to linked list
        _schedule.AddLast(match);

         if (!_rankings.Values.Contains(match.T1))
        {
            _rankings.Add(_rankings.Count,match.T1);
        }

         if (!_rankings.Values.Contains(match.T2))
        {
            _rankings.Add(_rankings.Count,match.T2);
        }
        

    }

   
    
    // Record match result and update rankings
    public void RecordMatchResult(Match match, int team1Score, int team2Score)
    {
        // TODO: Update team points and re-sort rankings
        match.Team1Score=team1Score;
        match.Team2Score=team2Score;

        _undoStack.Push(match.Clone());
        if (team1Score>team2Score)
        {
            match.T1.Points+=3;
        }
        else if (team1Score<team2Score)
        {
            match.T2.Points+=3;
        }
        else
        {
            match.T1.Points+=1;
            match.T2.Points+=1;
        }

        var sorted = _rankings.Values.OrderBy(t => t).ToList();
        _rankings.Clear();
        for(int i=0;i<sorted.Count;i++)
            _rankings.Add(i,sorted[i]);

    }
    
    // Undo last match
    public void UndoLastMatch()
    {
        // TODO: Use stack to revert last match
        if(_undoStack.Count==0) return;

        Match last = _undoStack.Pop();

        if(last.Team1Score>last.Team2Score)
            last.T1.Points-=3;
        else if(last.Team2Score> last.Team1Score)
            last.T2.Points-=3;
        else
        {
            last.T1.Points-=1;
            last.T2.Points-=1;
        }

        var sorted = _rankings.Values.OrderBy(t => t).ToList();
        _rankings.Clear();
        for(int i=0;i<sorted.Count;i++)
            _rankings.Add(i,sorted[i]);
    }
    
    // Get ranking position using binary search
    public int GetTeamRanking(Team team)
    {
        // TODO: Implement ranking lookup
        var list = _rankings.Values.ToList();
        int left =0, right=list.Count-1;

        while (left <= right)
        {
            int mid=(left+right)/2;

            if(list[mid]==team)
                return mid+1;

            if (list[mid].CompareTo(team) < 0)
            {
                left=mid+1;
            }
            else
                right=mid-1;
        }
        return -1;
    }

    public List<Team> GetRankings()
    {
        return _rankings.Values.ToList();
    }
}


class Program
{
    static void Main()
    {
        Tournament tournament = new Tournament();
        Team teamA = new Team { Name = "Team Alpha", Points = 0 };
        Team teamB = new Team { Name = "Team Beta", Points = 0 };
        Match match = new Match(teamA, teamB);

        tournament.ScheduleMatch(match);
        tournament.RecordMatchResult(match, 3, 1); // Team A wins

        var rankings = tournament.GetRankings();
        Console.WriteLine(rankings[0].Name); // Should output: Team Alpha

        tournament.UndoLastMatch();
        Console.WriteLine(teamA.Points); // Should output: 0 (back to original)

    }
}