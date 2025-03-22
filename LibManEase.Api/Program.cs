using LibManEase.DependencyResolver;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Resolve All Application layer dependencies via DependencyResolver or we can be Add ApplicationServices
builder.Services.ResolveApplicationDependency();

builder.Services.ResolveInfrastructureDependency(configuration, logConfig =>
{
    logConfig.LogFilePath = configuration.GetValue<string>("Logging:LogPath") ?? String.Empty;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
