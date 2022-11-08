namespace GitInsight.Core;

public interface IRepositoryRepository
{
    Task<(Response, RepositoryDto)> CreateAsync(RepositoryCreateDto repository);
    Task<(Response, RepositoryDto)> FindAsync(int repositoryId);
    Task<IReadOnlyCollection<RepositoryDto>> ReadAsync();
    Task<Response> UpdateAsync(RepositoryUpdateDto repository);
    Task<Response> DeleteAsync(int repositoryId);
}