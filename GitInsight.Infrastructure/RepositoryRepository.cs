namespace GitInsight.Infrastructure;

public class RepositoryRepository : IRepositoryRepository
{
    public (Response response, RepositoryDto repoistory) Create(RepositoryCreateDto repository)
    {
        throw new NotImplementedException();
    }

    public Response Delete(int repositoryId)
    {
        throw new NotImplementedException();
    }

    public (Response response, RepositoryDto repository) Find(int repositoryId)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyCollection<RepositoryDto> Read()
    {
        throw new NotImplementedException();
    }

    public Response Update(RepositoryUpdateDto repository)
    {
        throw new NotImplementedException();
    }
}