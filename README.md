

# Cliente 

Es una aplicación de .NET 6 diseñada para gestionar la información de clientes. Se basa en una arquitectura limpia (Clean Architecture) y está compuesto por varios componentes, incluyendo una API y tres bibliotecas de clases. Su objetivo principal es proporcionar una interfaz para crear, leer, actualizar y eliminar registros de clientes, manteniendo una estructura organizada y desacoplada.


## API Reference



 #####  Cliente

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `clienteId` | `int` |  Identificador unico |
| `Persona` | `object` | **Required**. object Persoa|
| `imagenBase64` | `object` |string |
| `contraseña` | `string` | **Required**. contraseña relacionada a un cliente|


 #####  Persona


| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `nombre` | ``string`` | **Required** Nombre del cliente |
| `genero` | ``string`` | **Required**. Genereo |
| `edad` | `int` | **Required**. edad cliente|
| `Tipoidentificacion` | `int` |**Required**  identificacion unico |
| `identificacion` | `int` |**Required**  identificacion unico |
| `direccion` | ``string`` | **Required**.  Description cliente|
| `telefono` | ``string`` | **Required**. Telefono cliente|




## Configuration de Base Datos

Configuration de string conexion appsettings.json

```bash
"AllowedHosts": "*",
  "ConnectionStrings": { 
    "DefaultConnection": {{ConnectionStrings}}
```

## Migraticion de Base Datos

para aplicar las migraciones a una base de datos. 
Ejecutar con la consola nguet. 

```bash
update-database 
``` 
o Tambien se puede especificar la ruta
```bash
dotnet ef {{RUTA pROJECT}} update-database 
``` 

## LINKS


 - [Podra encontrar la collecionde postman (AQUI) ](https://solar-rocket-100883.postman.co/workspace/s~cedc7df0-47ee-4832-860f-e080911bfbb2/collection/9370844-7eb246c0-2244-423d-95df-8055f83c233a?action=share&creator=9370844)

  - [FrontEnd para esta API (AQUI) ](https://github.com/JohandryPena/ClienteFront.ADO)




    
## Authors

- [JOHANDRI PEÑA PACHECO](https://github.com/JohandryPena)

