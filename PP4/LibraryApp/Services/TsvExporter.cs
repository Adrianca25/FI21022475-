using LibraryApp.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Services
{
    public static class TsvExporter

    {
        public static void ExportToTsv(LibraryContext context)

        {
            Console.WriteLine("Leyendo información desde la base de datos para generar archivos TSV...");

            // Obtener títulos junto con sus autores y etiquetas
            var titlesData = context.Titles
                .Include(t => t.Author)
                .Include(t => t.TitlesTags)
                    .ThenInclude(tt => tt.Tag)
                .AsEnumerable() // ejecución en memoria para agrupar luego
                .OrderByDescending(t => t.Author.AuthorName)
                .ThenByDescending(t => t.TitleName);

            // Agrupar los resultados por la primera letra del autor
            var authorsGrouped = titlesData
                .GroupBy(t => char.ToUpper(t.Author.AuthorName[0]))
                .OrderBy(g => g.Key);

            // Asegurar que exista el directorio 'data'
            Directory.CreateDirectory("data");

            foreach (var group in authorsGrouped)
            {
                string outputPath = Path.Combine("data", $"{group.Key}.tsv");

                using var writer = new StreamWriter(outputPath);
                writer.WriteLine("AuthorName\tTitleName\tTagName");

                foreach (var title in group)
                {
                    foreach (var tag in title.TitlesTags.Select(tt => tt.Tag))
                    {
                        writer.WriteLine($"{title.Author.AuthorName}\t{title.TitleName}\t{tag.TagName}");
                    }
                }

                Console.WriteLine($"Archivo generado: {outputPath}");
            }

            Console.WriteLine("Exportación completada con éxito.");
        }
    }
}