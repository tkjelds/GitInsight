namespace GitInsight.Infrastructure;

public class RepositoryRepository : IRepositoryRepository
{
    public async Task<RepositoryDto> CreateAsync(RepositoryCreateDto repository)
    {
        throw new NotImplementedException();
    }

    public async Task<RepositoryDto> FindAsync(int repositoryId)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyCollection<RepositoryDto>> ReadAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Response> UpdateAsync(RepositoryUpdateDto repository)
    {
        throw new NotImplementedException();
    }

    public async Task<Response> DeleteAsync(int repositoryId)
    {
        throw new NotImplementedException();
    }
}