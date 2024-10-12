var builder = DistributedApplication.CreateBuilder(args);

var postgre = builder.AddPostgres("contentplatform-db")
    .WithDataVolume()
    .WithPgAdmin();

var rabbitMq = builder.AddRabbitMQ("contentplatform-mq")
    .WithManagementPlugin();

builder.AddProject<Projects.ContentPlatform_Api>("contentplatform-api")
    .WithReference(postgre)
    .WithReference(rabbitMq);


builder.AddProject<Projects.ContentPlatform_Reporting_Api>("contentplatform-reporting-api")
    .WithReference(postgre)
    .WithReference(rabbitMq);

builder.AddProject<Projects.ContentPlatform_Presentation>("contentplatform-presentation");

builder.Build().Run();
