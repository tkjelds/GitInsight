public class AuthorMode : IStrategy
{
    public ICollection<(string,ICollection<(int,string)>)> authorNumberCommitsDaily;

    public void Assemble(Repository _repo)
    {
        var _authorNumberCommitsDaily = new List<(string,ICollection<(int,string)>)> ();
        var commitsByAuthor = _repo.Commits.GroupBy(d => d.Author.Name);

        foreach (var a in commitsByAuthor)
        {
            var author = (a.Key);
            
            var commitsByDate = a.GroupBy(d => d.Author.When.ToString("yyyy-MM-dd"));
            var numberCommitsDaily = new List<(int,string)> ();
            foreach (var d in commitsByDate)
            {
                numberCommitsDaily.Add((d.Count(),d.Key));
            }
            _authorNumberCommitsDaily.Add((author,numberCommitsDaily));
        }
        authorNumberCommitsDaily = _authorNumberCommitsDaily;
    }
    
    public void Print()
    {
        foreach (var authorCollection in authorNumberCommitsDaily)
        {
            var name = authorCollection.Item1;
            Console.WriteLine(authorCollection.Item1);
            
            foreach(var commit in authorCollection.Item2){
                var date = commit.Item2;
                var amount = commit.Item1;
                Console.WriteLine($"    {amount} {date}");
            }
        }
    }
}
