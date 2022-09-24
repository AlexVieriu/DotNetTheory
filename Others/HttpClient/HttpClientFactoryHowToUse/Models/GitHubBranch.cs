namespace HttpClientFactoryHowToUse.Models;

public class GitHubBranch
{
    public string name { get; set; }
    public Commit commit { get; set; }
    public bool _protected { get; set; }
}

public class Commit
{
    public string sha { get; set; }
    public string url { get; set; }
}
