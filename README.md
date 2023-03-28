# Laboratorio_Modulo_CSharp_WebApi
1 - Implementar los métodos que han quedado pendientes en la teoria:

Obtener un Actor por Id.
Modificar un Actor.
Borrar un Actor.
2 - Crear una nueva Web API para la gestión de un almacen. El controlador deberá permitir las siguientes funciones:

Añadir nuevo Artículo. Un artículo tendrá los siguientes campos:

Id.
Nombre.
Descripción.
Fecha de entrada.
Cantidad.
Por ejemplo:

{
  Id: 1,
  Nombre: "Camiseta Deportiva",
  Descripción: "Estas camisetas son especiales para actividades físicas, suelen ser de materiales sintéticos delgados que transpiran para mantener a las personas frescas, permitiendo que su rendimiento físico aumente",
  Cantidad: 100,
} 
Entrada de artículo. Donde se indica la cantidad a incrementar y el identificador del articulo. Por ejemplo, la llamada a entrada del artículo con id igual a 1 y 200 en cantidad establecerá el articulo con Id 1 con la cantidad que tuviera mas 200 unidades. Control de errores:

En el caso de no existir el articulo se deberá devolver un NotFound.
Retirada de artículo. Donde se indica la cantidad a decrementar y el identificador del articulo. Por ejemplo, la llamada a retirada del artículo con id igual a 1 y 200 en cantidad establecerá el articulo con Id 1 con la cantidad que tuviera menos 200 unidades. Control de errores:

En el caso de no existir el articulo se deberá devolver un NotFound.
Si no existe suficiente genero en el almacen, se deberá devolver un BadRequest con el mensaje de la excepción.