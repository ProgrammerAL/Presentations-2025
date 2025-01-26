
using Pulumi;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulumiInfra.Utilities;

public static class AzureAdRoleIdUtilities
{
    public const string AzureBuiltInReaderRoleId = "acdd72a7-3385-48ef-bd42-f606fba81ae7";
    public const string AzureBuiltInConhtributorRoleId = "b24988ac-6180-42a0-ab88-20f7382dd24c";
    public const string AzureBuiltInStorageBlobDataContributorRoleId = "ba92f5b4-2d11-453d-a403-e96b0029c9fe";

    public static string GenerateAzureReaderRoleId(string subscriptionId)
    {
        return AzureUtilities.GenerateRoleDefinitionId(subscriptionId, AzureBuiltInReaderRoleId);
    }

    public static string GenerateAzureContributorRoleId(string subscriptionId)
    {
        return AzureUtilities.GenerateRoleDefinitionId(subscriptionId, AzureBuiltInReaderRoleId);
    }

    public static string GenerateAzureStorageBlobDataContributorRoleId(string subscriptionId)
    {
        return AzureUtilities.GenerateRoleDefinitionId(subscriptionId, AzureBuiltInStorageBlobDataContributorRoleId);
    }
}
