var builder = WebApplication.CreateBuilder(args);

//add services to the container
var assembly = typeof(Program).Assembly;
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("DefaultConnection")!);
    opts.Schema.For<ShoppingCart>().Identity(x => x.UserName); //config for Username as an Identity
}).UseLightweightSessions();

var app = builder.Build();
//configure HTTP request pipeline

app.MapCarter();

app.Run();
