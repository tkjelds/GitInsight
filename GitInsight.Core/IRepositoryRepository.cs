namespace GitInsight.Core;

public interface IRepositoryRepository
{
    (Response response, RepositoryDto repoistory) Create(RepositoryCreateDto repository);
    (Response response, RepositoryDto repository) Find(int repositoryId);
    IReadOnlyCollection<RepositoryDto> Read();
    Response Update(RepositoryUpdateDto repository);
    Response Delete(int repositoryId);
}