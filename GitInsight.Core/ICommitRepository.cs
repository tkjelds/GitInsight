namespace GitInsight.Core;

public interface ICommitRepository
{
    Task<(Response, CommitDto)> CreateAsync(CommitCreateDto commit);
    Task<(Response, CommitDto)> FindAsync(int commitId);
    Task<IReadOnlyCollection<CommitDto>> ReadAsync();
    Task<Response> UpdateAsync(CommitUpdateDto commit);
    Task<Response> DeleteAsync(int commitId);
}