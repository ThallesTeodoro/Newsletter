using Microsoft.Extensions.Options;

namespace Newsletter.Api.Options;

public class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions>
{
    private readonly IConfiguration _configuration;
    private const string ConfigurationSectionName = "DatabaseOptions";

    public DatabaseOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(DatabaseOptions options)
    {
        var connectionString = _configuration.GetConnectionString("Database");

        options.ConnectionString = connectionString ?? string.Empty;

        _configuration.GetSection(ConfigurationSectionName).Bind(options);
    }
}
