using Mithril.Hr.Api;
using Mithril.Hr.Application.Configuration;
using Mithril.Hr.Configuration;
using Mithril.Hr.Persistence.Configuration;
using Mithril.Hr.Persistence.Seeds;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDomain();
builder.Services.AddApplication();

builder.Services.AddPersistence();
if (!builder.Environment.IsTesting())
{
    builder.Services.AddPersistenceDbContext();
}

builder.Services.AddControllers();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    await DbSeeder.Run(app.Services, app.Environment.EnvironmentName);

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program;