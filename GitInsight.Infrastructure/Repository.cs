namespace GitInsight.Infrastructure;

public class Repository
{
    public int Id { get; set; }
    public String? Name { get; set; }
    public virtual ICollection<Commit>? Commits {get; set;}
}
