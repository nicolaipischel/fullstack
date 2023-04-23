namespace Api;

internal sealed class RepositoryOptions
{
    public const string SectionName = "Database";
    
    public string FilePath { get; init; } = string.Empty;
}