using LibraryApp.Data;
using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Services
{
    public static class CsvImporter

    {
        public static void LoadFromCsvFile(LibraryContext context)

        {
            // Si ya existen registros, no se hace nada
            if (context.Authors.Any())
            {
                Console.WriteLine("Ya existen datos en la base, no se cargará el CSV.");
                return;
            }

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "data", "books.csv");

            if (!File.Exists(filePath))
            {
                Console.WriteLine("No se encontró el archivo 'books.csv' dentro de la carpeta 'data'.");
                return;
            }

            Console.WriteLine("Cargando datos iniciales desde el archivo CSV...");
            using var reader = new StreamReader(filePath);

            bool isHeader = true;
            int insertedCount = 0;
            string? line;

            while ((line = reader.ReadLine()) != null)
            {
                // Ignorar encabezado y líneas vacías
                if (isHeader)
                {
                    isHeader = false;
                    continue;
                }

                if (string.IsNullOrWhiteSpace(line))
                    continue;

                // Separar valores del CSV (respetando comillas)
                string[] columns = ParseCsvLine(line);

                if (columns.Length < 3)
                {
                    Console.WriteLine($"Línea omitida (datos incompletos): {line}");
                    continue;
                }

                string authorName = columns[0].Trim();
                string titleName = columns[1].Trim();
                string[] tagNames = columns[2].Split('|', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

                // Buscar o crear el autor
                var author = context.Authors.FirstOrDefault(a => a.AuthorName == authorName);
                if (author == null)
                {
                    author = new Author { AuthorName = authorName };
                    context.Authors.Add(author);
                }

                // Crear título asociado al autor
                var title = new Title
                {
                    TitleName = titleName,
                    Author = author
                };
                context.Titles.Add(title);

                // Asignar etiquetas al título
                foreach (var tagText in tagNames)
                {
                    var tag = context.Tags.FirstOrDefault(t => t.TagName == tagText);
                    if (tag == null)
                    {
                        tag = new Tag { TagName = tagText };
                        context.Tags.Add(tag);
                    }

                    context.TitlesTags.Add(new TitleTag
                    {
                        Title = title,
                        Tag = tag
                    });
                }

                insertedCount++;
            }

            context.SaveChanges();
            Console.WriteLine($"Carga completada. Se insertaron {insertedCount} registros correctamente.");
        }

        // Método auxiliar: divide una línea CSV respetando comillas dobles
        private static string[] ParseCsvLine(string line)
        {
            var values = new List<string>();
            var currentValue = "";
            bool insideQuotes = false;

            foreach (char c in line)
            {
                if (c == '"')
                {
                    insideQuotes = !insideQuotes;
                }
                else if (c == ',' && !insideQuotes)
                {
                    values.Add(currentValue);
                    currentValue = "";
                }
                else
                {
                    currentValue += c;
                }
            }

            values.Add(currentValue);
            return values.ToArray();
        }
    }
}