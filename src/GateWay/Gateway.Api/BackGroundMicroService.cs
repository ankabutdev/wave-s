namespace Gateway.Api;

public class BackGroundMicroService(ILogger<BackGroundMicroService> logger) 
    : BackgroundService, IHostedService, IHostedLifecycleService
{
    private readonly ILogger<BackGroundMicroService> _logger = logger;

    public Task StartedAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Background service started.");
        return Task.CompletedTask;
    }

    public Task StartingAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Background service starting.");
        return Task.CompletedTask;
    }

    public Task StoppedAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Background service stopped.");
        return Task.CompletedTask;
    }

    public Task StoppingAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Background service stopping.");
        return Task.CompletedTask;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Background service is executing.");

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
