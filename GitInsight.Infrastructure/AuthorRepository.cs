namespace GitInsight.Infrastructure;

public class AuthorRepository : IAuthorRepository
{
    public (Response, AuthorDto) Create(AuthorCreateDto author)
    {
        throw new NotImplementedException();
    }

    public (Response, AuthorDto) Find(int authorId)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyCollection<AuthorDto> Read()
    {
        throw new NotImplementedException();
    }
    
    public Response Update(AuthorUpdateDto author)
    {
        throw new NotImplementedException();
    }

    public Response Delete(int authorId)
    {
        throw new NotImplementedException();
    }
}