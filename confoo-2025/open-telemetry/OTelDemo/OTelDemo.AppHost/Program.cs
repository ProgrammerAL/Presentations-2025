using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var sqlServer = builder.AddSqlServer("sql");

var sqlDb = sqlServer.AddDatabase("sqldb");

var internalApiService = builder.AddProject<Projects.OTelDemo_InternalApiService>("internal-api")
                                .WithReference(sqlDb);
                                //.WithEnvironment("OTEL_EXPORTER_OTLP_ENDPOINT", "https://api.honeycomb.io")
                                //.WithEnvironment("OTEL_EXPORTER_OTLP_HEADERS", "");

var publicApiService = builder.AddProject<Projects.OTelDemo_PublicApiService>("public-api")
                              .WithReference(internalApiService);
                              //.WithEnvironment("OTEL_EXPORTER_OTLP_ENDPOINT", "https://api.honeycomb.io")
                              //.WithEnvironment("OTEL_EXPORTER_OTLP_HEADERS", "");

builder.Build().Run();
