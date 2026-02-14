# 📦 Products CRUD API

Este proyecto es una **API REST básica** desarrollada en **ASP.NET Core Web API** que implementa un CRUD (Create, Read, Update, Delete) para la entidad **Producto**, utilizando **Controllers** y **DTOs (Data Transfer Objects)**.

La API maneja una sola entidad llamada `Producto` y utiliza dos DTOs:
- Uno para mostrar la lista de productos.
- Otro para crear productos con validaciones `[Required]`.

---

## 🚀 Tecnologías utilizadas

- ASP.NET Core Web API  
- C#  
- Controllers  
- DTOs  
- Entity Framework Core  
- Data Annotations (`[Required]`)  
- Swagger  

---





## 📁 Estructura del proyecto

ProductsCRUDAPIs.api
│
├── Products.Controllers
│ └── ProductsController.cs
│
├── Products.Domain
│ └── Entities
│ └── Products.cs
│
├── Products.DTOs
│ ├── ProductListDTO.cs
│ └── ProductDTOs.cs
│
├── Program.cs
└── appsettings.json








---

## 🧩 Entidad principal

La API trabaja con una sola entidad:

Product
{
Id
Name
Price
Stock
State
}


---

## 📌 DTOs utilizados

### 1️⃣ ProductListDto (listar productos)

Se usa para mostrar los productos sin exponer directamente la entidad:

ProductListDto
{
Id
Name
Price
}


---

### 2️⃣ ProductCreateDto (crear producto)

Contiene validaciones obligatorias:

ProductCreateDto
{
[Required]
Name

[Required]
State
[Required]
Price

[Required]
Stock
}




---

## 🔄 Funcionalidades CRUD

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | /api/products | Obtener todos los productos |
| GET | /api/products/{id} | Obtener producto por ID |
| POST | /api/products | Crear un producto |
| PUT | /api/products/{id} | Actualizar un producto |
| DELETE | /api/products/{id} | Eliminar un producto |

---

## 🛠️ Validaciones

- Se utilizan Data Annotations `[Required]` en el DTO de creación.
- Si un campo requerido no es enviado, la API retorna un error **400 Bad Request**.

---

## ▶️ Ejecución del proyecto

1. Clonar el repositorio:
git clone https://github.com/JoseAngelDev2/-Programaci-n-II-C-/tree/origin/homework2

2. 
Abrir el proyecto en Visual Studio.

3.
Ejecutar la aplicación:

dotnet run


