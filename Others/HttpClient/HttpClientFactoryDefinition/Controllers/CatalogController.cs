namespace HttpClientFactoryDefinition.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CatalogController : ControllerBase
{
    private readonly ICatalogService _catalogSvc;

    public CatalogController(ICatalogService catalogSvc)
    {
        _catalogSvc = catalogSvc;
    }

    public async Task<IActionResult> Index(int? BrandFilterApplied,
                                           int? typesFilterApplied,
                                           int? page,
                                           [FromQuery] string errorMsg)
    {
        var itemPage = 10;
        var catalog = await _catalogSvc.GetCatalogItems(page ?? 0,
                                                       itemPage,
                                                       BrandFilterApplied,
                                                       typesFilterApplied);
        return null;
    }
}
