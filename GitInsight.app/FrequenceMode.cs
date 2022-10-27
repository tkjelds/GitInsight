public class FrequenceMode : IStrategy
{
    public ICollection<(int,string)> NumberCommitsDaily;

    public void Assemble(Repository _repo)
    {
        var _NumberCommitsDaily = new List<(int,string)> ();
        var groupedByDate = _repo.Commits.GroupBy(c => c.Author.When.DateTime.ToShortDateString());
        foreach (var _date_ in groupedByDate)
        {
            var CommitAmount = 0;
            var date = _date_.Key;
            foreach (var commit in _date_)
            {
                CommitAmount++;
            }
            _NumberCommitsDaily.Add((CommitAmount,date));
        }
        NumberCommitsDaily = _NumberCommitsDaily;
    }

    public void Print()
    {
        foreach (var commit in NumberCommitsDaily)
        {
            var date = commit.Item2;
            var amount = commit.Item1;
            Console.WriteLine($"{amount} {date}");
        }
    }
}