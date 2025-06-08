var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.FeedbackService>("feedbackservice", "https");

await builder.Build().RunAsync();
