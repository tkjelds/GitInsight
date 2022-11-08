namespace GitInsight.Core;

public interface ICommitRepository
{
    Task<CommitDto> CreateAsync(CommitCreateDto commit);
    Task<CommitDto?> FindAsync(int commitId);
    Task<IReadOnlyCollection<CommitDto>> ReadAsync();
    Task<Response> UpdateAsync(CommitUpdateDto commit);
    Task<Response> DeleteAsync(int commitId);
}