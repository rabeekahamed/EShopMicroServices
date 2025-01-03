var builder = WebApplication.CreateBuilder(args);

//Add services to the container
builder.Services.AddCarter(); //Carter will manage the API endpoints
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
}); //MediatR will handle business Logic

var app = builder.Build();


//Configure the HTTP request pipeline
app.MapCarter();

app.Run();
