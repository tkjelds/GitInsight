namespace GitInsight.Core;

public record CommitDto(int Id, string Message, DateTimeOffset Date);

public record CommitCreateDto(string Message, DateTimeOffset Date);

public record CommitUpdateDto(int Id, string Message);