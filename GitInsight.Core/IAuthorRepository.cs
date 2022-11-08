namespace GitInsight.Core;

public interface IAuthorRepository
{
    Task<(Response, AuthorDto)> CreateAsync(AuthorCreateDto author);
    Task<(Response, AuthorDto)> FindAsync(int authorId);
    Task<IReadOnlyCollection<AuthorDto>> ReadAsync();
    Task<Response> UpdateAsync(AuthorUpdateDto author);
    Task<Response> DeleteAsync(int authorId);
}