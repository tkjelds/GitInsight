namespace GitInsight.Infrastructure.Tests;

public sealed class AuthorRepositoryTests : IAsyncDisposable
{
    private readonly SqliteConnection _connection;
    private readonly Context _context;
    private readonly AuthorRepository _repository;

    public AuthorRepositoryTests()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();
        var builder = new DbContextOptionsBuilder<Context>();
        builder.UseSqlite(_connection);
        var context = new Context(builder.Options);
        context.Database.EnsureCreated();

        Author authorOne = new Author("Bob");
        Author authorTwo = new Author("John");
        Author authorThree = new Author("Carl");

        context.Authors.AddRange(authorOne, authorTwo, authorThree);
        context.SaveChanges();

        _context = context;
        _repository = new AuthorRepository(_context);
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