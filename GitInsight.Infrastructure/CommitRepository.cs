namespace GitInsight.Infrastructure;

public class CommitRepository : ICommitRepository
{
    private readonly Context _context;

    public CommitRepository(Context context)
    {
        _context = context;
    }

    public async Task<CommitDto> CreateAsync(CommitCreateDto commit)
    {
        var entity = new Commit(commit.Message);

        _context.Commits.Add(entity);

        await _context.SaveChangesAsync();

        return new CommitDto(entity.Id, entity.Message, entity.Date);
    }

    public async Task<CommitDto?> FindAsync(int commitId)
    {
        var commits = from c in _context.Commits
                      where c.Id == commitId
                      select new CommitDto(c.Id, c.Message, c.Date);
        
        return await commits.FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyCollection<CommitDto>> ReadAsync()
    {
        var commits = from c in _context.Commits
                      orderby c.Message
                      select new CommitDto(c.Id, c.Message, c.Date);

        return await commits.ToArrayAsync();
    }
    
    public async Task<Response> UpdateAsync(CommitUpdateDto commit)
    {
        var entity = await _context.Commits.FindAsync(commit.Id);

        Response response;

        if (entity is null)
        {
            response = NotFound;
        }
        else
        {
            entity.Message = commit.Message;

            await _context.SaveChangesAsync();

            response = Updated;
        }

        return response;
    }

    public async Task<Response> DeleteAsync(int commitId)
    {
        var entity = await _context.Commits.FindAsync(commitId);

        Response response;

        if (entity is null)
        {
            response = NotFound;
        }
        else
        {
            _context.Commits.Remove(entity);

            await _context.SaveChangesAsync();

            response = Deleted;
        }

        return response;
    }
}