namespace RawCoding_HttpClient.Consumer.Client;

public class CustomHttpClient
{
    private readonly HttpClient _client;
    private string _guidy;

    public CustomHttpClient(HttpClient client)
    {
        _client = client;

        // base configuration (should never change)
        _guidy = Guid.NewGuid().ToString();
        client.DefaultRequestHeaders.Add("StartUpHeader", Guid.NewGuid().ToString());
    }

    public Task<string> GetHome()
    {
        return _client.GetStringAsync($"/homes/{_guidy}");
    }
}
