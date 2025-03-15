using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Azure.Data.Tables;
using Azure.Identity;

using Microsoft.Extensions.Options;

using static FeedbackService.Database.CommentsRepository;

namespace FeedbackService.Database;

public interface ICommentsRepository
{
    Task<Azure.Response> StoreCommentsAsync(StoreCommentsEntity entity);
}

public class CommentsRepository : ICommentsRepository
{
    public record StoreCommentsEntity(string Comments);

    private readonly IOptions<StorageConfig> _storageConfig;

    public CommentsRepository(IOptions<StorageConfig> storageConfig)
    {
        _storageConfig = storageConfig;
    }

    public async Task<Azure.Response> StoreCommentsAsync(StoreCommentsEntity entity)
    {
        var itemKey = Guid.NewGuid().ToString();

        var tableUri = new Uri(_storageConfig.Value.Endpoint);
        var tableClient = new TableClient(tableUri, _storageConfig.Value.TableName, new DefaultAzureCredential());

        await tableClient.CreateIfNotExistsAsync();

        // Make a dictionary entity by defining a <see cref="TableEntity">.
        var tableEntity = new TableEntity(itemKey, itemKey)
        {
            { "Comments", entity.Comments },
        };

        return await tableClient.AddEntityAsync(tableEntity);
    }
}
