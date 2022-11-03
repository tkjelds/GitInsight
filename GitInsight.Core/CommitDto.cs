namespace GitInsight.Core;

public record CommitDto(int Id, DateTimeOffset Date);

public record CommitCreateDto();

public record CommitUpdateDto(int Id);