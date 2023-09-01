var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api/ping", () => "pong");
app.MapGet("/api/env", () => Environment.GetEnvironmentVariables());

app.Run();