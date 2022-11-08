namespace GitInsight.Core;

public interface IRepositoryRepository
{
    Task<RepositoryDto> CreateAsync(RepositoryCreateDto repository);
    Task<RepositoryDto?> FindAsync(int repositoryId);
    Task<IReadOnlyCollection<RepositoryDto>> ReadAsync();
    Task<Response> UpdateAsync(RepositoryUpdateDto repository);
    Task<Response> DeleteAsync(int repositoryId);
}