namespace GitInsight.Infrastructure.Tests;

public sealed class RepositoryRepositoryTests : IAsyncDisposable
{
    private readonly SqliteConnection _connection;
    private readonly Context _context;
    private readonly RepositoryRepository _repository;

    public RepositoryRepositoryTests()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();
        var builder = new DbContextOptionsBuilder<Context>();
        builder.UseSqlite(_connection);
        var context = new Context(builder.Options);
        context.Database.EnsureCreated();

        Repository repositoryOne = new Repository("Our awesome application");
        Repository repositoryTwo = new Repository("Test repository");
        Repository repositoryThree = new Repository("Forked from Bob");

        context.Repositories.AddRange(repositoryOne, repositoryTwo, repositoryThree);
        context.SaveChanges();

        _context = context;
        _repository = new RepositoryRepository(_context);
    }

    [Fact]
    public void Test1()
    {

    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
        await _connection.DisposeAsync();
    }
}