using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Mithril.Hr.Infrastructure.Persistence.Model;
using Mithril.Hr.Infrastructure.Tests.Configuration;

namespace Mithril.Hr.Api.Tests.Controllers;

public abstract class IntegrationTestBase : WebApplicationFactory<Program>
{
    private readonly JsonSerializerOptions _jsonSerializerOptions = new ();

    protected HttpClient Client => Server.Services.GetRequiredService<HttpClient>();
    protected DataContext DbContext => Server.Services.GetRequiredService<DataContext>();

    protected IntegrationTestBase()
    {
        _jsonSerializerOptions.PropertyNameCaseInsensitive = true;

        DbContext.Database.EnsureCreated();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder
            .UseEnvironment(HostEnvironmentExtensions.Testing)
            .ConfigureTestServices(services => services
                .AddSingleton(_ => CreateClient())
                .AddPersistenceTestDbContext());
    }

    protected StringContent GetContent<T>(T instance)
    {
        var content = new StringContent(
            JsonSerializer.Serialize(instance, _jsonSerializerOptions));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        return content;
    }

    protected async Task<T> GetResult<T>(HttpResponseMessage response)
        => JsonSerializer.Deserialize<T>(
               await response.Content.ReadAsStringAsync(),
               _jsonSerializerOptions)
           ?? throw new InvalidOperationException();
}
