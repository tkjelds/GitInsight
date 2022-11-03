namespace GitInsight.Core;

public interface IAuthorRepository
{
    (Response response, AuthorDto author) Create(AuthorCreateDto author);
    (Response response, AuthorDto author) Find(int authorId);
    IReadOnlyCollection<AuthorDto> Read();
    Response Update(AuthorUpdateDto author);
    Response Delete(int authorId);
}