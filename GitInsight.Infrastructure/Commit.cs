namespace GitInsight.Infrastructure;
public class Commit
{
    public int Id { get; set; }
    public DateTimeOffset Date { get; set; }
    public virtual Author? Author { get; set; }
    public virtual Repository? Repository { get; set; }    
}
