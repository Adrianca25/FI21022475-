using TextProcessorApi;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Map endpoints
app.MapTextEndpoints();

app.Run();
