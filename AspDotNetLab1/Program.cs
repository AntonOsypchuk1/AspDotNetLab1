using AspDotNetLab1.middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", () => "Hello, World!");

app.Map("/home", home =>
{
    home.Map("/index", Index);
    home.Map("/about", About);
});


app.UseFileServer(new FileServerOptions
{
    EnableDirectoryBrowsing = true,
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), @"static"))
});

app.UseMiddleware<SecretMiddleware>();
app.UseMiddleware<LoggerMiddleware>();

app.UseExceptionHandler("/Error");
app.UseStatusCodePagesWithReExecute("/Error/{0}");


app.Run();



void Index(IApplicationBuilder appBuilder)
{
    appBuilder.Run(async context => await context.Response.WriteAsync("Index"));
}
void About(IApplicationBuilder appBuilder)
{
    appBuilder.Run(async context => await context.Response.WriteAsync("About"));
}