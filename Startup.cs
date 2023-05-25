namespace RngApp;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSignalR();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseStaticFiles();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/api/getNumber", async context =>
            {
                int firstNumber = Random.Shared.Next(0, 1000);
                await context.Response.WriteAsync(firstNumber.ToString());
            });

            endpoints.MapHub<NumberHub>("/numberHub");

            endpoints.MapGet("/", async context =>
            {
                context.Response.Redirect("/index.html");
            });

            endpoints.MapFallbackToFile("index.html");
        });
    }
}