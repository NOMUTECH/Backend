using MongoDB.Driver;



public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        var serviceCollection = services.AddSingleton<IMongoClient>(s => new MongoClient("mongodb://localhost:27017"));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
