﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Azure.Data.Tables;
using Azure.Identity;

using Microsoft.Extensions.Options;

using ProgrammerAl.SourceGenerators.PublicInterfaceGenerator.Attributes;

namespace FeedbackFunctionsApp.Persistence;

public interface IAzTablePersister
{
    ValueTask StoreItemAsync(string comments);
}

public class AzTablePersister : IAzTablePersister
{
    private readonly IOptions<StorageConfig> _storageConfig;

    public AzTablePersister(IOptions<StorageConfig> storageConfig)
    {
        _storageConfig = storageConfig;
    }

    public async ValueTask StoreItemAsync(string comments)
    {
        var itemKey = Guid.NewGuid().ToString();

        var uri = new Uri(_storageConfig.Value.TableEndpoint);
        var token = new DefaultAzureCredential();
        var tableClient = new TableClient(uri, tableName: "Comments", token);

        await tableClient.CreateIfNotExistsAsync();

        // Make a dictionary entity by defining a <see cref="TableEntity">.
        var tableEntity = new TableEntity(itemKey, itemKey)
        {
            { "Comments", comments },
        };

        await tableClient.AddEntityAsync(tableEntity);
    }
}
