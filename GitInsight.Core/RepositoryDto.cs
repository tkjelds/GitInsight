namespace GitInsight.Core;

public record RepositoryDto(int Id, string Name);

public record RepositoryCreateDto(string Name);

public record RepositoryUpdateDto(int Id, string Name);