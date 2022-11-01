namespace GitInsight.test;

public class AuthorModeTests
{
    AuthorMode _auth;

    public AuthorModeTests()
    {
        var path = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.Parent!.FullName;
        var target = @"\TestRepos\su19-grp7";
        var repo = new Repository(path + target);
        AuthorMode auth = new AuthorMode();
        auth.Assemble(repo);
        _auth = auth;
    }

    // [Fact]
    // public void AuthorMode_given_repo_prints_authors_and_commits()
    // {
    //     // Arrange
    //     var authorMode = new AuthorMode();
    //     authorMode.Assemble(repo);

    //     using var writer = new StringWriter();
    //     Console.SetOut(writer);

    //     var expected = "";

    //     // Act
    //     authorMode.Print();
    //     var actual = writer.GetStringBuilder().ToString().TrimEnd();

    //     // Assert
    //     Assert.Equal(expected, actual);

    // }

    // [Fact]
    // public void AuthorMode_given_repo_returns_correct_number_of_dates()
    // {
    //     // Arrange
    //     var authorMode = new AuthorMode();
    //     authorMode.Assemble(repo);

    //     // Act
    //     var actual = authorMode.authorNumberCommitsDaily.Count();

    //     // Assert
    //     Assert.Equal(3, actual);
    // }

    // [Fact]
    // public void AuthorMode_given_repo_returns_correct_dates()
    // {
    //     // Arrange
    //     var authorMode = new AuthorMode();
    //     authorMode.Assemble(repo);

    //     // Act
    //     var actual = authorMode.authorNumberCommitsDaily.First().Item2;

    //     // Assert
    //     Assert.Equal(null, actual);
    // }
}