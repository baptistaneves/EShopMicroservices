var builder = WebApplication.CreateBuilder(args);

//Add Services to the container
builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

var app = builder.Build();

//Configure the http request pipeline
app.UseApiServices();

app.Run();
