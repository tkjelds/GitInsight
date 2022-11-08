namespace GitInsight.Core;

public record CommitDto(int Id, string Message, DateTimeOffset Date);

public record CommitCreateDto(string Message);

public record CommitUpdateDto(int Id);