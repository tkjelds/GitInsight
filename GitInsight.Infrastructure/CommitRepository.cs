namespace GitInsight.Infrastructure;

public class CommitRepository : ICommitRepository
{
    public (Response, CommitDto) Create(CommitCreateDto commit)
    {
        throw new NotImplementedException();
    }

    public (Response, CommitDto) Find(int commitId)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyCollection<CommitDto> Read()
    {
        throw new NotImplementedException();
    }
    
    public Response Update(CommitUpdateDto commit)
    {
        throw new NotImplementedException();
    }

    public Response Delete(int commitId)
    {
        throw new NotImplementedException();
    }
}