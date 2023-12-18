await using(var context = new CustomersContext)
{
    await context.Database.EnsureDeleteAsync();
    await context.Database.EnsureCreateAsync();

    context.AddRange(SampleData.CreateSampleCustomers());

}
