namespace HttpClientFactoryDefinition.Services;

public class CatalogService : ICatalogService
{
    public Task<Catalog> GetCatalogItems(int page, int take, int? brand, int? type)
    {
        throw new NotImplementedException();
    }    
}
