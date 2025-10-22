using System.Collections.Generic;
using System.IO;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var list = new List<object>();

app.MapGet("/", () => Results.Redirect("/swagger"));

app.MapPost("/", ([FromHeader(Name = "xml")] bool xml) =>
{
    if (xml)
    {
        // Convertir a XML
        var xmlSerializer = new XmlSerializer(list.GetType());
        using var stringWriter = new StringWriter();
        xmlSerializer.Serialize(stringWriter, list);
        return Results.Content(stringWriter.ToString(), "application/xml");
    }

    return Results.Ok(list); // JSON por defecto
});
app.MapPut("/", ([FromForm] int quantity, [FromForm] string type) =>
{
    var random = new Random();

    if (quantity <= 0)
        return Results.BadRequest(new { error = "La cantidad debe ser mayor a 0" });

    if (type == "int")
    {
        for (int i = 0; i < quantity; i++)
            list.Add(random.Next());
    }
    else if (type == "float")
    {
        for (int i = 0; i < quantity; i++)
            list.Add(random.NextSingle());
    }
    else
    {
        return Results.BadRequest(new { error = "El tipo debe ser int o float" });
    }

    return Results.Ok(new { message = $"{quantity} elementos agregados como {type}" });
}).DisableAntiforgery();
//chatGPT
app.MapDelete("/", ([FromForm] int quantity) =>
{
    if (quantity <= 0)
        return Results.BadRequest(new { error = "La cantidad debe ser mayor a 0" });

    if (quantity > list.Count)
        return Results.BadRequest(new { error = "La cantidad a eliminar es mayor a la cantidad de elementos en la lista" });

    for (int i = 0; i < quantity; i++)
        list.RemoveAt(0);

    return Results.Ok(new { message = $"{quantity} elementos eliminados" });
}).DisableAntiforgery();
//chatGPT
app.MapPatch("/", () =>
{
    list.Clear();
    return Results.Ok();
}).DisableAntiforgery();

app.Run();
public static class XmlHelper
{
    public static string ToXml<T>(T obj)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var ms = new MemoryStream();
        serializer.Serialize(ms, obj);
        return Encoding.UTF8.GetString(ms.ToArray());
    }
}