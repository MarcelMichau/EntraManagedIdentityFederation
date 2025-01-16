var builder = DistributedApplication.CreateBuilder(args);

var downstreamApi = builder.AddProject<Projects.DownstreamApi>("downstreamapi");

var upstreamApi = builder.AddProject<Projects.UpstreamApi>("upstreamapi")
    .WithReference(downstreamApi);

builder.AddProject<Projects.ClientApp>("clientapp")
    .WithReference(upstreamApi)
    .WithExternalHttpEndpoints();

builder.Build().Run();
