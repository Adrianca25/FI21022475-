# PP2 - Operaciones binarias (ASP.NET Core MVC)

*Adrián Cordero Abarca
*FI21022475

## Estructura del repo
Repo.
└── PP2
    ├── PP2Web
    ├── PP2.sln
    └── README.md

## Tecnologías
- C# / .NET 8.0
- ASP.NET Core MVC (Razor)
- DataAnnotations para validación

## Comandos dotnet (CLI)
```bash
dotnet new sln -n PP2
dotnet new mvc -o PP2Web
dotnet sln PP2.sln add PP2Web/PP2Web.csproj
dotnet build
dotnet run --project PP2Web
