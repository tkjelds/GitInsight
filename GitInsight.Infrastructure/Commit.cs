namespace GitInsight.Infrastructure;
public class Commit
{
    public int Id { get; set; }
    public string Message { get; set; }
    public DateTimeOffset Date { get; set; }

    public int? AuthorId { get; set; }
    public virtual Author? Author { get; set; }

    public int? RepositoryId { get; set; }
    public virtual Repository? Repository { get; set; }

    public Commit(String message, DateTimeOffset date)
    {
        Message = message;
        Date = date;
    }   
}
