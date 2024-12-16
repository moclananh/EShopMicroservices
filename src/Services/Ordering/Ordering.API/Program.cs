
using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Data.Extentions;

var builder = WebApplication.CreateBuilder(args);

//add services to contaniner
builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

var app = builder.Build();

//configured the HTTP request pipeline
app.UseApiServices();
if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.Run();
