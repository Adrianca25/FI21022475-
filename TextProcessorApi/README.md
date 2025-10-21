Adrián Cordero Abarca
FI21022475

Comandos .NET
Crea un proyecto ASP.NET Core Web minimal API llamado TextProcessorApi: dotnet new web -n TextProcessorApi
Crea un archivo de solución .sln: dotnet new sln -n TextProcessorApiSolution
Agregar el proyecto a la solución: dotnet sln TextProcessorApiSolution.sln add TextProcessorApi/TextProcessorApi.csproj
Restaurar dependencias:dotnet restore
Compilar el proyecto:dotnet build
Ejecutar el proyecto: dotnet run

Paginas Usadas
CampusMVP y Satckoverflow

Chatbots
Chatgpt y Copilot

¿Es posible enviar valores en el Body (por ejemplo, en el Form) del Request de tipo GET?
En papel es posible enviar valores en el Body de una solicitud GET, ya que la especificación HTTP/1.1 no lo prohíbe del todo, pero no es recomendado y no se debería hacer. La razón principal es que el body no tiene semántica definida para los métodos GET, lo que significa que el servidor puede ignorarlo o rechazar la solicitud. 

https://stackoverflow-com.translate.goog/questions/978061/http-get-with-request-body?_x_tr_sl=en&_x_tr_tl=es&_x_tr_hl=es&_x_tr_pto=sge#:~:text=Entonces%2C%20sí%2C%20puedes%20enviar%20un,especificación%20(trabajo%20en%20progreso).&text=Sí%2C%20se%20puede%20enviar%20el,el%20URI%20de%20la%20solicitud.&text=De%20la%20especificación%20HTTP%201.1,implementaciones%20existentes%20rechacen%20la%20solicitud.


¿Qué ventajas y desventajas observa con el Minimal API si se compara con la opción de utilizar Controllers?

Minimal API

Ventajas
Es simple y consistente: El Minimal API usa una sintaxis más simple y menos lineas de codigo. Lo que lo hace mejor para proyectos como microservicios o prototipos.
Menos \"boiler-plate\": Eliminan la necesidad de clases de controlador y decoradores como [Route] y [ApiController], lo que resulta en menos código de configuración.
Mayor rendimiento: La menor sobrecarga puede traducirse en un rendimiento ligeramente más rápido en algunos casos, y un tiempo de inicio más veloz.

Desventajas

Menor estructura: Para aplicaciones grandes con muchos endpoints, la falta de una estructura de controlador puede hacer que el código sea más difícil de organizar y mantener. 
Menos características integradas: Carecen de validación de modelos de solicitud integrada y la devolución de ProblemDetails por defecto para errores como NotFound, que sí se obtienen con los controladores. 
Gestión de OpenAPI: La configuración de OpenAPI puede ser menos potente y requerir más trabajo manual en comparación con los controladores. 

Controladores

Ventajas

Estructura Organizada: el código original sigue la estructura tradicional de un controlador de ASP.NET, lo que puede ser más familiar para desarrolladores con experiencia en ASP.NET MVC.
Enrutamiento Centralizado: el enrutamiento se define a nivel de clase y método, lo que puede ser más claro y fácil de seguir, especialmente en aplicaciones con múltiples controladores y rutas complejas.

Desventajas

Menos rendimiento: Generalmente tienen una sobrecarga mayor que las API mínimas, lo que puede afectar el rendimiento en aplicaciones que requieren alta velocidad. 
Más código: Requieren más \"boilerplate\" y configuraciones, lo que puede hacerlos más verbosos y lentos de escribir.

https://www.campusmvp.es/recursos/post/controladores-o-minimal-apis-para-crear-apis-con-net.aspx