using Carter;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//add services to the container
builder.Services.AddCarter();
//configure HTTP request pipeline

app.Run();
