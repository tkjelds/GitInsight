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

        Repository repositoryOne = new Repository("Our awesome application") { Id = 1 };
        Repository repositoryTwo = new Repository("Test repository") { Id = 2 };
        Repository repositoryThree = new Repository("Forked from Bob") { Id = 3 };

        context.Repositories.AddRange(repositoryOne, repositoryTwo, repositoryThree);
        context.SaveChanges();

        _context = context;
        _repository = new RepositoryRepository(_context);
    }

    [Fact]
    public async Task CreateAsync_Returns_RepositoryDto()
    {
        //arrange
        var repository = new RepositoryCreateDto("My repository");

        var expected = new RepositoryDto(4, "My repository");

        //act
        var actual = await _repository.CreateAsync(repository);

        //assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task FindAsync_With_Existing_Id_Returns_RepositoryDto()
    {
        //arrange
        var expected = new RepositoryDto(2, "Test repository");

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
    public async Task ReadAsync_Returns_RepositoryDto_Array()
    {
        //arrange
        var expected = new RepositoryDto[] 
        {
            //Returns list sorted by names, hence the ordering
            new (3, "Forked from Bob"),
            new (1, "Our awesome application"),
            new (2, "Test repository")
        };

        //act
        var actual = await _repository.ReadAsync();

        //assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task UpdateAsync_With_Existing_Repository_Returns_Updated_Response()
    {
        //arrange
        var updatedRepository = new RepositoryUpdateDto(1, "Our not so awesome application");

        var expected = new RepositoryDto(1, "Our not so awesome application");

        //act
        var response = await _repository.UpdateAsync(updatedRepository);

        var actual = await _repository.FindAsync(1);

        //assert
        Assert.Equal(Updated, response);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task UpdateAsync_With_Non_Existing_Repository_Returns_NotFound_Response()
    {
        //arrange
        var updatedRepository = new RepositoryUpdateDto(55, "This repository does not exist");

        //act
        var response = await _repository.UpdateAsync(updatedRepository);

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