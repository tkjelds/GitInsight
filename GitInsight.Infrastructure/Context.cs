namespace GitInsight.Infrastructure;

public sealed class Context : DbContext
{
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Commit> Commits => Set<Commit>();
    public DbSet<Repository> Repositories => Set<Repository>();

    public Context(DbContextOptions<Context> options):base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}