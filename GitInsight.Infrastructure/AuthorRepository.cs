namespace GitInsight.Infrastructure;

public class AuthorRepository : IAuthorRepository
{
    public async Task<AuthorDto> CreateAsync(AuthorCreateDto author)
    {
        throw new NotImplementedException();
    }

    public async Task<AuthorDto> FindAsync(int authorId)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyCollection<AuthorDto>> ReadAsync()
    {
        throw new NotImplementedException();
    }
    
    public async Task<Response> UpdateAsync(AuthorUpdateDto author)
    {
        throw new NotImplementedException();
    }

    public async Task<Response> DeleteAsync(int authorId)
    {
        throw new NotImplementedException();
    }
}