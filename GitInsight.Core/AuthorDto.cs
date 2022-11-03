namespace GitInsight.Core;

public record AuthorDto(int Id, string Name);

public record AuthorCreateDto(string Name);

public record AuthorUpdateDto(int Id, string Name);