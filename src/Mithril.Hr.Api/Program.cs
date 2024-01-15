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
    var scope = app.Services.CreateScope();
    var dbSeeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();
    await dbSeeder.Run();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program;