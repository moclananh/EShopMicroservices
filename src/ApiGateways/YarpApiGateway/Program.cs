var builder = WebApplication.CreateBuilder(args);

//add services to the container

//config yarp api gateway
builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();
//configured HTTP request pipeline
app.MapReverseProxy();
app.MapGet("/", () => "Hello World!");

app.Run();
