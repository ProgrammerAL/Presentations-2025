using FeedbackService;
using FeedbackService.Database;

using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICommentsRepository, CommentsRepository>();

//Setup Config
builder.Services.AddOptions<ServiceConfig>().Bind(builder.Configuration.GetSection(nameof(ServiceConfig)));
builder.Services.AddSingleton<IValidateOptions<ServiceConfig>, ServiceConfigValidateOptions>();

builder.Services.AddOptions<StorageConfig>().Bind(builder.Configuration.GetSection(nameof(StorageConfig)));
builder.Services.AddSingleton<IValidateOptions<StorageConfig>, StorageConfigValidateOptions>();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
