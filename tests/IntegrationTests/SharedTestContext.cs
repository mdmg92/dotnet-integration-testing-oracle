using Ductus.FluentDocker.Builders;
using Ductus.FluentDocker.Model.Common;
using Ductus.FluentDocker.Services;

namespace IntegrationTests;

public class SharedTestContext : IAsyncLifetime
{
    private static readonly string DockerComposeFile = Path
        .Combine(Directory.GetCurrentDirectory(),
            (TemplateString)"../../../docker-compose.integration.yml");

    private readonly ICompositeService _dockerService = new Builder()
        .UseContainer()
        .UseCompose()
        .FromFile(DockerComposeFile)
        .RemoveOrphans()
        .Build();

    public Task InitializeAsync()
    {
        _dockerService.Start();

        return Task.CompletedTask;
    }

    public Task DisposeAsync()
    {
        _dockerService.Stop();

        return Task.CompletedTask;
    }
}
