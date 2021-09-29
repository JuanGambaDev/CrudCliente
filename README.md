# CrudCliente

En este proyecto se realizo la función CRUD(Create,Read, Update, Delete) de la entidad cliente, la cual posee los atributos: Id, Nombres, Apellidos, Direccion. 

El proyecto se realizo en lenguaje C# a traves de la plataforma .NET

La solución se manejo con una arquitectura de tres capas, las cuales cumplen las siguientes funciones:
1. Presentacion : Contiene la vista al usuario usando la interfaz windows forms.
2. Entidades: Contiene las clases que interactuan en el proyecto, en este caso solo fue cliente.
3. Persistencia: Esta es la capa que realiza la interaccion con la base de datos, en este caso se uso una base de datos relacional en SQL Server.

# Funcionamiento del software:

## Crear cliente

Pantalla inicial:

<img src="./ImgFuncionamiento/Create/PantallaInicial.png"

Formulario Agregar Cliente:

<img src= "./ImgFuncionamiento/Create/AgregarDatos.png">

Base de datos con cliente agregado:

<img src= "./ImgFuncionamiento/Create/Datos Agregados.png">

## Actualizar datos de cliente

Seleccionar cliente para actualizar:

<img src= "./ImgFuncionamiento/Update/SeleccionCliente.png">

Se modifican los datos en el formulario:

<img src= "./ImgFuncionamiento/Update/ModificandoDatos.png">

Datos actualizados en la base de datos:

<img src= "./ImgFuncionamiento/Update/DatosModificados.png">

## Eliminar Cliente

Seleccionar cliente a eliminar:
<img src= "./ImgFuncionamiento/Delete/SeleccionEliminar.png.png">

Cliente eliminado de la base de datos:

<img src= "./ImgFuncionamiento/Delete/DatoEliminado.png">





