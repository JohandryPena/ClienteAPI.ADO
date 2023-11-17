
# Cliente 

Es una aplicación de .NET 6 diseñada para gestionar la información de clientes. Se basa en una arquitectura limpia (Clean Architecture) y está compuesto por varios componentes, incluyendo una API y tres bibliotecas de clases. Su objetivo principal es proporcionar una interfaz para crear, leer, actualizar y eliminar registros de clientes, manteniendo una estructura organizada y desacoplada.


## API Reference

#### Get all items

```http
  GET    /api/Clientes
  GET    /api/Clientes/1
  POST   /api/Clientes
  PUT    /api/Clientes/1
  DELETE /api/Clientes/1
  
```

 #####  Cliente

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `clienteId` | `int` |  Identificador unico |
| `Persona` | `object` | **Required**. object Persoa|
| `contraseña` | `string` | **Required**. contraseña relacionada a un cliente|


 #####  Persona


| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `nombre` | ``string`` | **Required** Nombre del cliente |
| `genero` | ``string`` | **Required**. Genereo |
| `edad` | `int` | **Required**. edad cliente|
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




    
## Authors

- [JOHANDRI PEÑA PACHECO](https://github.com/JohandryPena)

