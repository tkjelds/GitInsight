namespace GitInsight.Infrastructure;

public class RepositoryRepository : IRepositoryRepository
{
    public Task<(Response, RepositoryDto)> CreateAsync(RepositoryCreateDto repository)
    {
        throw new NotImplementedException();
    }

    public Task<Response> DeleteAsync(int repositoryId)
    {
        throw new NotImplementedException();
    }

    public Task<(Response, RepositoryDto)> FindAsync(int repositoryId)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<RepositoryDto>> ReadAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response> UpdateAsync(RepositoryUpdateDto repository)
    {
        throw new NotImplementedException();
    }
}