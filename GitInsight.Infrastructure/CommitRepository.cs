namespace GitInsight.Infrastructure;

public class CommitRepository : ICommitRepository
{
    public Task<(Response, CommitDto)> CreateAsync(CommitCreateDto commit)
    {
        throw new NotImplementedException();
    }

    public Task<(Response, CommitDto)> FindAsync(int commitId)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<CommitDto>> ReadAsync()
    {
        throw new NotImplementedException();
    }
    
    public Task<Response> UpdateAsync(CommitUpdateDto commit)
    {
        throw new NotImplementedException();
    }

    public Task<Response> DeleteAsync(int commitId)
    {
        throw new NotImplementedException();
    }
}