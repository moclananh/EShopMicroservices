using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

//add services to the container

//config yarp api gateway
builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

//config limit rate (prevented too many request/per time)
builder.Services.AddRateLimiter(rateLimitOption =>
{
    rateLimitOption.AddFixedWindowLimiter("fixed", options =>
    {
        options.Window = TimeSpan.FromSeconds(10);
        options.PermitLimit = 5;
    });
});

var app = builder.Build();

//configured HTTP request pipeline
app.MapReverseProxy();
app.MapGet("/", () => "Hello World!");

app.Run();
