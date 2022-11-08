namespace GitInsight.Infrastructure.Tests;

public sealed class CommitRepositoryTests : IAsyncDisposable
{
    private readonly SqliteConnection _connection;
    private readonly Context _context;
    private readonly CommitRepository _repository;

    public CommitRepositoryTests()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();
        var builder = new DbContextOptionsBuilder<Context>();
        builder.UseSqlite(_connection);
        var context = new Context(builder.Options);
        context.Database.EnsureCreated();

        Commit commitOne = new Commit("Added this awesome feature!");
        Commit commitTwo = new Commit("Fixed some bugs in the code");
        Commit commitThree = new Commit("Implemented some tests");

        context.Commits.AddRange(commitOne, commitTwo, commitThree);
        context.SaveChanges();

        _context = context;
        _repository = new CommitRepository(_context);
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