namespace GitInsight.Infrastructure;

public class RepositoryRepository : IRepositoryRepository
{
    private readonly Context _context;

    public RepositoryRepository(Context context)
    {
        _context = context;
    }

    public async Task<RepositoryDto> CreateAsync(RepositoryCreateDto repository)
    {
        var entity = new Repository(repository.Name);

        _context.Repositories.Add(entity);

        await _context.SaveChangesAsync();

        return new RepositoryDto(entity.Id, entity.Name);
    }

    public async Task<RepositoryDto?> FindAsync(int repositoryId)
    {
        var repositories = from r in _context.Repositories
                           where r.Id == repositoryId
                           select new RepositoryDto(r.Id, r.Name);

        return await repositories.FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyCollection<RepositoryDto>> ReadAsync()
    {
        var repositories = from r in _context.Repositories
                           orderby r.Name
                           select new RepositoryDto(r.Id, r.Name);
        
        return await repositories.ToArrayAsync();
    }

    public async Task<Response> UpdateAsync(RepositoryUpdateDto repository)
    {
        var entity = await _context.Repositories.FindAsync(repository.Id);

        Response response;

        if (entity is null)
        {
            response = NotFound;
        }
        else
        {
            entity.Name = repository.Name;

            await _context.SaveChangesAsync();

            response = Updated;
        }

        return response;
    }

    public async Task<Response> DeleteAsync(int repositoryId)
    {
        var entity = await _context.Repositories.FindAsync(repositoryId);

        Response response;

        if (entity is null)
        {
            response = NotFound;
        }
        else
        {
            _context.Repositories.Remove(entity);

            await _context.SaveChangesAsync();

            response = Deleted;
        }

        return response;
    }
}