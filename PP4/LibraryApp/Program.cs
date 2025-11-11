﻿using LibraryApp.Data;
using LibraryApp.Services;

using var db = new LibraryContext();
db.Database.EnsureCreated();

if (!db.Authors.Any())
{
    Console.WriteLine("No hay registros. Cargando desde CSV...");
    CsvImporter.LoadFromCsvFile(db);
}
else
{
    Console.WriteLine("Generando archivos TSV...");
    TsvExporter.ExportToTsv(db);
}

