namespace GitInsight.Infrastructure;

public class Repository
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int? AuthorId { get; set; }
    public virtual Author? Author { get; set; }
    
    public virtual ICollection<Commit>? Commits {get; set;}

    public Repository(string name)
    {
        Name = name;
    }
}
