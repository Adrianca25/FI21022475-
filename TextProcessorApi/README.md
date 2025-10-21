Adri�n Cordero Abarca
FI21022475

Comandos .NET
Crea un proyecto ASP.NET Core Web minimal API llamado TextProcessorApi: dotnet new web -n TextProcessorApi
Crea un archivo de soluci�n .sln: dotnet new sln -n TextProcessorApiSolution
Agregar el proyecto a la soluci�n: dotnet sln TextProcessorApiSolution.sln add TextProcessorApi/TextProcessorApi.csproj
Restaurar dependencias:dotnet restore
Compilar el proyecto:dotnet build
Ejecutar el proyecto: dotnet run

Paginas Usadas
CampusMVP y Satckoverflow

Chatbots
Chatgpt y Copilot

�Es posible enviar valores en el Body (por ejemplo, en el Form) del Request de tipo GET?
En papel es posible enviar valores en el Body de una solicitud GET, ya que la especificaci�n HTTP/1.1 no lo proh�be del todo, pero no es recomendado y no se deber�a hacer. La raz�n principal es que el body no tiene sem�ntica definida para los m�todos GET, lo que significa que el servidor puede ignorarlo o rechazar la solicitud. 

https://stackoverflow-com.translate.goog/questions/978061/http-get-with-request-body?_x_tr_sl=en&_x_tr_tl=es&_x_tr_hl=es&_x_tr_pto=sge#:~:text=Entonces%2C%20s�%2C%20puedes%20enviar%20un,especificaci�n%20(trabajo%20en%20progreso).&text=S�%2C%20se%20puede%20enviar%20el,el%20URI%20de%20la%20solicitud.&text=De%20la%20especificaci�n%20HTTP%201.1,implementaciones%20existentes%20rechacen%20la%20solicitud.


�Qu� ventajas y desventajas observa con el Minimal API si se compara con la opci�n de utilizar Controllers?

Minimal API

Ventajas
Es simple y consistente: El Minimal API usa una sintaxis m�s simple y menos lineas de codigo. Lo que lo hace mejor para proyectos como microservicios o prototipos.
Menos \"boiler-plate\": Eliminan la necesidad de clases de controlador y decoradores como [Route] y [ApiController], lo que resulta en menos c�digo de configuraci�n.
Mayor rendimiento: La menor sobrecarga puede traducirse en un rendimiento ligeramente m�s r�pido en algunos casos, y un tiempo de inicio m�s veloz.

Desventajas

Menor estructura: Para aplicaciones grandes con muchos endpoints, la falta de una estructura de controlador puede hacer que el c�digo sea m�s dif�cil de organizar y mantener. 
Menos caracter�sticas integradas: Carecen de validaci�n de modelos de solicitud integrada y la devoluci�n de ProblemDetails por defecto para errores como NotFound, que s� se obtienen con los controladores. 
Gesti�n de OpenAPI: La configuraci�n de OpenAPI puede ser menos potente y requerir m�s trabajo manual en comparaci�n con los controladores. 

Controladores

Ventajas

Estructura Organizada: el c�digo original sigue la estructura tradicional de un controlador de ASP.NET, lo que puede ser m�s familiar para desarrolladores con experiencia en ASP.NET MVC.
Enrutamiento Centralizado: el enrutamiento se define a nivel de clase y m�todo, lo que puede ser m�s claro y f�cil de seguir, especialmente en aplicaciones con m�ltiples controladores y rutas complejas.

Desventajas

Menos rendimiento: Generalmente tienen una sobrecarga mayor que las API m�nimas, lo que puede afectar el rendimiento en aplicaciones que requieren alta velocidad. 
M�s c�digo: Requieren m�s \"boilerplate\" y configuraciones, lo que puede hacerlos m�s verbosos y lentos de escribir.

https://www.campusmvp.es/recursos/post/controladores-o-minimal-apis-para-crear-apis-con-net.aspx