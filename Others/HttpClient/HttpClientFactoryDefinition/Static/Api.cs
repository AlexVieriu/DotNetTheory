namespace HttpClientFactoryDefinition.Static;

public static class Api
{
    private static string BaseUrl = "";
    public static class Catalog
    {
        public static string GetAllCatalogItems(string _remoteServiceBaseUrl,
                                                int page, int take, int brand, int type)
        {
            return $"{_remoteServiceBaseUrl}/?page={page}&take={take}&brand={brand}&type={type}";
        }
    }
}
