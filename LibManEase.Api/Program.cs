using LibManEase.Application;
using LibManEase.DependencyResolver;

var builder = WebApplication.CreateBuilder(args);

// Both ApplicationLayer Dependencies and PresentationLayer dependencies are registered in the LibManEase.DependencyInjection project
builder.Services.SetupServiceCollection(builder.Configuration);

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
