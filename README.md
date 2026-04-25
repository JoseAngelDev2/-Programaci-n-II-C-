# 🪚 Caspentry Workshop API

### Backend moderno en **.NET** con arquitectura limpia + Frontend integrado

---

## 🚀 Descripción

**Caspentry Workshop** es una API desarrollada en **ASP.NET Core** que gestiona un sistema completo para un taller de carpintería:

* 👷 Gestión de carpinteros
* 👤 Gestión de clientes
* 📁 Gestión de proyectos
* 🪵 Control de materiales
* 🚚 Seguimiento de entregas

El proyecto sigue una **arquitectura limpia (Clean Architecture)**, separando responsabilidades para facilitar escalabilidad, mantenimiento y testing.

---

## 🧱 Arquitectura del proyecto

```bash
src/
│
├── Caspentry_Workshop.Api            # 🌐 Capa de presentación (Controllers, endpoints)
├── Caspentry_Workshop.Application    # 🧠 Lógica de aplicación (DTOs, interfaces)
├── Caspentry_Workshop.Domain         # 📦 Entidades del dominio
├── Caspentry_Workshop.Infrastructure # 🔌 Acceso a datos (EF Core, repositorios)
│
└── Front                            # 🎨 Frontend (opcional / en desarrollo)
```

---

## ⚙️ Tecnologías utilizadas

* ⚡ .NET 10 / ASP.NET Core
* 🗄️ Entity Framework Core
* 🧩 Arquitectura limpia (Clean Architecture)
* 🔗 API REST
* 🐳 Docker (para despliegue)

---

## 📦 Funcionalidades principales

### 👷 Carpinteros

* Crear, editar, eliminar y listar carpinteros
* Gestión de especialidad, salario y contacto

### 👤 Clientes

* CRUD completo
* Relación con proyectos

### 📁 Proyectos

* Gestión de estado (Pendiente, En Proceso, Completado)
* Asociación con clientes
* Control de costos

### 🪵 Materiales

* Inventario de materiales
* Control de cantidades y precios

### 🚚 Entregas

* Seguimiento de entregas por proyecto
* Estados: Pendiente / Entregado

---

## 🔗 Endpoints principales

```http
GET     /api/{entity}
GET     /api/{entity}/{id}
POST    /api/{entity}
PUT     /api/{entity}/{id}
DELETE  /api/{entity}/{id}
```

📌 Donde `{entity}` puede ser:

* carpinter
* client
* project
* material
* delivery

---

## 🧪 Ejemplo de Request (Delivery)

```json
{
  "deliveryDate": "2026-04-24T00:00:00",
  "statusDelivery": "Pendiente",
  "projectId": 1
}
```

---

## 🐳 Deploy con Docker (Render)

### 📁 Ubicación del Dockerfile

```
src/Caspentry_Workshop.Api/Dockerfile
```

### ▶️ Ejecutar localmente

```bash
docker build -t caspentry-api .
docker run -p 10000:10000 caspentry-api
```

---

## 🌍 Deploy en la nube

Recomendado usar:

* Render → Backend (.NET API)
* Vercel → Frontend

---

## ⚠️ Configuración importante

### Puerto para producción (Render)

```csharp
app.Urls.Add("http://0.0.0.0:10000");
```

---

### CORS (para frontend)

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});
```

---

## 💡 Próximas mejoras

* ✅ Implementar DTOs completos
* 🔄 AutoMapper
* 🔐 Autenticación (JWT / OAuth)
* 📊 Dashboard en frontend (Completado con vercel)
* 📦 Integración con base de datos en la nube (Completado con supabase)

---

## 👨‍💻 Autor

Desarrollado por **JoseAngelDev2** 🚀

---
