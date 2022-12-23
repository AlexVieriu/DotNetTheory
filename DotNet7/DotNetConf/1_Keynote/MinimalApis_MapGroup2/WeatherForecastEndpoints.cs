public static class WeatherForecastEndpoints
{
    public static void MapWeatherForecastEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/WeatherForecast").WithTags(nameof(WeatherForecast));

        group.MapGet("/", async (MinimalApis2Context db) =>
        {
            return await db.WeatherForecast.ToListAsync();
        })
        .WithName("GetAllWeatherForecasts")
        .WithOpenApi()
        .Produces<List<WeatherForecast>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, MinimalApis2Context db) =>
        {
            return await db.WeatherForecast.FindAsync(id)
                is WeatherForecast model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetWeatherForecastById")
        .WithOpenApi()
        .Produces<WeatherForecast>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async (int id,
                                     WeatherForecast weatherForecast,
                                     MinimalApis2Context db) =>
        {
            var foundModel = await db.WeatherForecast.FindAsync(id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(weatherForecast);
            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateWeatherForecast")
        .WithOpenApi()
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (WeatherForecast weatherForecast,
                                  MinimalApis2Context db) =>
        {
            db.WeatherForecast.Add(weatherForecast);
            await db.SaveChangesAsync();
            return Results.Created($"/api/WeatherForecast/{weatherForecast.Id}", weatherForecast);
        })
        .WithName("CreateWeatherForecast")
        .WithOpenApi()
        .Produces<WeatherForecast>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (int id, MinimalApis2Context db) =>
        {
            if (await db.WeatherForecast.FindAsync(id) is WeatherForecast weatherForecast)
            {
                db.WeatherForecast.Remove(weatherForecast);
                await db.SaveChangesAsync();
                return Results.Ok(weatherForecast);
            }

            return Results.NotFound();
        })
        .WithName("DeleteWeatherForecast")
        .WithOpenApi()
        .Produces<WeatherForecast>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}