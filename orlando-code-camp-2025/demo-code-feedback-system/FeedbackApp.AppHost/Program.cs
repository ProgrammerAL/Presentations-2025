var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.FeedbackService>("feedbackservice", "https");

builder.Build().Run();
