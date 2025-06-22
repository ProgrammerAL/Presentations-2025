using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pulumi;

namespace PulumiInfra.Config;

public record GlobalConfig(
    ServiceConfig ServiceConfig,
    ApiConfig ApiConfig)
{
    public static async Task<GlobalConfig> LoadAsync(Pulumi.Config config)
    {
        var azureClientConfig = await Pulumi.AzureNative.Authorization.GetClientConfig.InvokeAsync();

        var apiConfig = new ApiConfigDto
        {
            ClientConfig = azureClientConfig,
            Location = config.Require("location"),
            ResourceGroupName = config.Require("azure-resource-group-name"),
            FunctionsPackagePath = config.Require("functions-package-path")
        };

        return new GlobalConfig(
            ServiceConfig: config.RequireObject<ServiceConfigDto>("service-config").GenerateValidConfigObject(),
            ApiConfig: apiConfig.GenerateValidConfigObject());
    }
}

