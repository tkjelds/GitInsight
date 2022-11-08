namespace GitInsight.Infrastructure;

public class AuthorRepository : IAuthorRepository
{
    private readonly Context _context;

    public AuthorRepository(Context context)
    {
        _context = context;
    }

    public async Task<AuthorDto> CreateAsync(AuthorCreateDto author)
    {
        var entity = new Author(author.Name);

        _context.Authors.Add(entity);

        await _context.SaveChangesAsync();

        return new AuthorDto(entity.Id, entity.Name);
    }

    public async Task<AuthorDto?> FindAsync(int authorId)
    {
        var authors = from a in _context.Authors
                      where a.Id == authorId
                      select new AuthorDto(a.Id, a.Name);

        return await authors.FirstOrDefaultAsync(); 
    }

    public async Task<IReadOnlyCollection<AuthorDto>> ReadAsync()
    {
        var authors = from a in _context.Authors
                      orderby a.Name
                      select new AuthorDto(a.Id, a.Name);
        
        return await authors.ToArrayAsync();
    }
    
    public async Task<Response> UpdateAsync(AuthorUpdateDto author)
    {
        var entity = await _context.Authors.FindAsync(author.Id);

        Response response;

        if (entity is null)
        {
            response = NotFound;
        }
        else
        {
            entity.Name = author.Name;

            await _context.SaveChangesAsync();

            response = Updated;
        }

        return response;
    }

    public async Task<Response> DeleteAsync(int authorId)
    {
        var entity = await _context.Authors.FindAsync(authorId);

        Response response;

        if (entity is null)
        {
            response = NotFound;
        }
        else
        {
            _context.Authors.Remove(entity);

            await _context.SaveChangesAsync();

            response = Deleted;
        }

        return response;
    }
}