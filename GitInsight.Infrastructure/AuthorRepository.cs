namespace GitInsight.Infrastructure;

public class AuthorRepository : IAuthorRepository
{
    public Task<(Response, AuthorDto)> CreateAsync(AuthorCreateDto author)
    {
        throw new NotImplementedException();
    }

    public Task<(Response, AuthorDto)> FindAsync(int authorId)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<AuthorDto>> ReadAsync()
    {
        throw new NotImplementedException();
    }
    
    public Task<Response> UpdateAsync(AuthorUpdateDto author)
    {
        throw new NotImplementedException();
    }

    public Task<Response> DeleteAsync(int authorId)
    {
        throw new NotImplementedException();
    }
}