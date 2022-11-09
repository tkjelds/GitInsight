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

        Author authorOne = new Author("Bob") { Id = 1 };
        Author authorTwo = new Author("John") { Id = 2 };
        Author authorThree = new Author("Carl") { Id = 3 };

        context.Authors.AddRange(authorOne, authorTwo, authorThree);
        context.SaveChanges();

        _context = context;
        _repository = new AuthorRepository(_context);
    }

     [Fact]
    public async Task CreateAsync_Returns_AuthorDto()
    {
        //arrange
        var author = new AuthorCreateDto("Eva");

        var expected = new AuthorDto(4, "Eva");

        //act
        var actual = await _repository.CreateAsync(author);

        //assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task FindAsync_With_Existing_Id_Returns_AuthorDto()
    {
        //arrange
        var expected = new AuthorDto(2, "John");

        //act
        var actual = await _repository.FindAsync(2);

        //assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task FindAsync_With_Non_Existing_Id_Returns_Null()
    {
        //act
        var actual = await _repository.FindAsync(55);

        //assert
        Assert.Null(actual);
    }

    [Fact]
    public async Task ReadAsync_Returns_AuthorDto_Array()
    {
        //arrange
        var expected = new AuthorDto[] 
        {
            //Returns sorted list by names, hence the ordering
            new (1, "Bob"),
            new (3, "Carl"),
            new (2, "John")
        };

        //act
        var actual = await _repository.ReadAsync();

        //assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task UpdateAsync_With_Existing_Author_Returns_Updated_Response()
    {
        //arrange
        var updatedAuthor = new AuthorUpdateDto(1, "Alex");

        var expected = new AuthorDto(1, "Alex");

        //act
        var response = await _repository.UpdateAsync(updatedAuthor);

        var actual = await _repository.FindAsync(1);

        //assert
        Assert.Equal(Updated, response);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task UpdateAsync_With_Non_Existing_Author_Returns_NotFound_Response()
    {
        //arrange
        var updatedAuthor = new AuthorUpdateDto(55, "Malle");

        //act
        var response = await _repository.UpdateAsync(updatedAuthor);

        //assert
        Assert.Equal(NotFound, response);
    }

    [Fact]
    public async Task DeleteAsync_With_Existing_Id_Returns_Deleted_Response()
    {
        //act
        var response = await _repository.DeleteAsync(1);

        var deleted = await _context.Authors.FindAsync(1);

        //assert
        Assert.Equal(Deleted, response);
        Assert.Null(deleted);
    }

    [Fact]
    public async Task DeleteAsync_With_Non_Existing_Id_Returns_NotFound_Response()
    {
        //act
        var response = await _repository.DeleteAsync(55);

        //assert
        Assert.Equal(NotFound, response);
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
        await _connection.DisposeAsync();
    }
}