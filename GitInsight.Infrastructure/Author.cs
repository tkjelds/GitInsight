namespace GitInsight.Infrastructure;

public class Author
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public virtual ICollection<Repository>? Repositories { get; set; }
}
