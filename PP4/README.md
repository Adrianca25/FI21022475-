PP4 

Nombre: Adrián Caordero Abarca
Carné:FI21022475

## Comandos dotnet usados

dotnet new sln -n BooksSolution
dotnet new console -n LibraryApp --framework net8.0
dotnet sln BooksSolution.sln add LibraryApp/LibraryApp.csproj
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet build
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

## Prompts y paginas consultadas

-https://learn.microsoft.com/en-us/ef/core/cli/dotnet
-https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools
- Se consultó ChatGPT (OpenAI), Gemini y Copilot .

Preguntas

¿Cómo cree que resultaría el uso de la estrategia de Code First para crear y actualizar una base de datos de tipo NoSQL (como por ejemplo MongoDB)? ¿Y con Database First? ¿Cree que habría complicaciones con las Foreign Keys?

Creo que sí es posible usar la idea de Code First con MongoDB, pero habría que adaptarla al modelo NoSQL, aprovechando su flexibilidad y entendiendo que no todo el comportamiento de Entity Framework se puede aplicar igual.
Pienso que Database First no se adapta bien a MongoDB, y que las Foreign Keys no tienen un equivalente directo, lo que puede generar más trabajo al desarrollar la lógica de relaciones entre los datos. 


---

¿Cuál carácter, además de la coma (,) y el Tab (\t), se podría usar para separar valores en un archivo de texto con el objetivo de ser interpretado como una tabla (matriz)? ¿Qué extensión le pondría y por qué? Por ejemplo: Pipe (|) con extensión .pipe.

Otro carácter que se podría usar es el punto y coma (;), ya que es común en algunos países donde la coma se usa como separador decimal. Podría usarse con la extensión .csv o incluso .scsv. Elegiría esa extensión porque deja claro que los valores están separados por punto y coma y facilita su lectura en programas como Excel o Google Sheets.
