public class MinimalApis2Context : DbContext
{
    public MinimalApis2Context (DbContextOptions<MinimalApis2Context> options)
        : base(options)
    {
    }

    public DbSet<WeatherForecast> WeatherForecast { get; set; } = default!;
}
