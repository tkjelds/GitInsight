namespace GitInsight.Core;

public interface IAuthorRepository
{
    Task<AuthorDto> CreateAsync(AuthorCreateDto author);
    Task<AuthorDto?> FindAsync(int authorId);
    Task<IReadOnlyCollection<AuthorDto>> ReadAsync();
    Task<Response> UpdateAsync(AuthorUpdateDto author);
    Task<Response> DeleteAsync(int authorId);
}