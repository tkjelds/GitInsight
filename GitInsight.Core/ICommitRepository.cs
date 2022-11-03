namespace GitInsight.Core;

public interface ICommitRepository
{
    (Response, CommitDto) Create(CommitCreateDto commit);
    (Response, CommitDto) Find(int commitId);
    IReadOnlyCollection<CommitDto> Read();
    Response Update(CommitUpdateDto commit);
    Response Delete(int commitId);
}