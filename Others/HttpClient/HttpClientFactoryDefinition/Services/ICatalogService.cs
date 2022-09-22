namespace HttpClientFactoryDefinition.Services;

public interface ICatalogService
{
   Task<Catalog> GetCatalogItems(int page, int take, int? brand, int? type);
}
