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
    public async Task CreateAsync_Returns_CommitDto()
    {
        //arrange
        var commit = new CommitCreateDto("Test commit message");

        var expected = new CommitDto(4, "Test commit message", DateTimeOffset.Now);

        //act
        var actual = await _repository.CreateAsync(commit);

        //assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.Message, actual.Message);
    }

    [Fact]
    public async Task FindAsync_With_Existing_Id_Returns_CommitDto()
    {
        //arrange
        var image = new byte [5];

        var expected = new CommitDto(1, "Added this awesome feature!", DateTimeOffset.Now);

        //act
        var actual = await _repository.FindAsync(1);

        //assert
        Assert.Equal(expected.Id, actual!.Id);
        Assert.Equal(expected.Message, actual.Message);
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
    public async Task ReadAsync_Returns_CommitDto_Array()
    {
        //act
        var actual = await _repository.ReadAsync();

        //assert
        Assert.Equal(3, actual.Count);
    }

    [Fact]
    public async Task UpdateAsync_With_Existing_Photo_Returns_Updated_Response()
    {
        //arrange
        var updatedCommit = new CommitUpdateDto(1, "Added some new features");

        var expected = new CommitDto(1, "Added some new features", DateTimeOffset.Now);

        //act
        var response = await _repository.UpdateAsync(updatedCommit);

        var actual = await _repository.FindAsync(1);

        //assert
        Assert.Equal(Updated, response);
        Assert.Equal(expected.Id, actual!.Id);
        Assert.Equal(expected.Message, actual.Message);
    }

    [Fact]
    public async Task UpdateAsync_With_Non_Existing_Photo_Returns_NotFound_Response()
    {
        //arrange
        var updatedCommit = new CommitUpdateDto(55, "This commit does not exist");

        //act
        var response = await _repository.UpdateAsync(updatedCommit);

        //assert
        Assert.Equal(NotFound, response);
    }

    [Fact]
    public async Task DeleteAsync_With_Existing_Id_Returns_Deleted_Response()
    {
        //act
        var response = await _repository.DeleteAsync(1);

        var deleted = await _context.Commits.FindAsync(1);

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