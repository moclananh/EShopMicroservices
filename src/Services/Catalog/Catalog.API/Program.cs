var builder = WebApplication.CreateBuilder(args);

// add services to the container.
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});


var app = builder.Build();

// configuare the HTTP request pipeline.
app.MapCarter();
app.Run();
