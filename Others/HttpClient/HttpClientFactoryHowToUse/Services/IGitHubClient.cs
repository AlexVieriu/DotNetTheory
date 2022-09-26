namespace HttpClientFactoryHowToUse.Services;

public interface IGitHubClient
{
    [Get("/repos/dotnet/AspNetCore.Docs/branches")]
    Task<IEnumerable<GitHubBranch>> GetBranchesAsync();
}
