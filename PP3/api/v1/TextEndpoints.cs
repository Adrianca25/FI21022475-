using TextProcessorApi.Models;
using TextProcessorApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace TextProcessorApi;

public static class TextEndpoints
{
    public static void MapTextEndpoints(this WebApplication app)
    {
        app.MapPost("/api/v1/text/process", (TextRequest req) =>
        {
            var service = new TextService();
            var result = service.ToUpper(req.Text);
            return Results.Ok(new { original = req.Text, processed = result });
        });
    }
}
