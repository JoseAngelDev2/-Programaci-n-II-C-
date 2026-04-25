# 📄 Documento de Requerimientos del Sistema

## 🪚 Caspentry Workshop

---

## 1. 📌 Introducción

El presente documento define los requerimientos funcionales y no funcionales del sistema **Caspentry Workshop**, una solución tecnológica orientada a la gestión integral de un taller de carpintería.

El sistema permite administrar carpinteros, clientes, proyectos, materiales y entregas, centralizando la información y optimizando los procesos operativos del negocio.

---

## 2. 🎯 Objetivo del Sistema

Desarrollar una aplicación web que permita:

* Gestionar recursos humanos (carpinteros)
* Administrar clientes y sus proyectos
* Controlar materiales e inventario
* Supervisar entregas y estados de proyectos

---

## 3. 🧱 Alcance

El sistema cubrirá:

* Operaciones CRUD completas para todas las entidades
* Gestión de relaciones entre clientes, proyectos y entregas
* Visualización de información desde un frontend web
* Persistencia de datos en base de datos en la nube (Supabase)

---

## 4. 👥 Usuarios del Sistema

* 👨‍🔧 Administrador del taller
* 👨‍💼 Encargado de proyectos
* 👤 Personal operativo (uso limitado)

---

## 5. 📦 Requerimientos Funcionales

### 5.1 Gestión de Carpinteros

* RF-01: El sistema debe permitir registrar carpinteros
* RF-02: El sistema debe permitir editar información de carpinteros
* RF-03: El sistema debe permitir eliminar carpinteros
* RF-04: El sistema debe listar todos los carpinteros
* RF-05: El sistema debe almacenar:

  * Nombre
  * Especialidad
  * Teléfono
  * Salario

---

### 5.2 Gestión de Clientes

* RF-06: Registrar clientes
* RF-07: Editar clientes
* RF-08: Eliminar clientes
* RF-09: Listar clientes
* RF-10: Cada cliente puede tener múltiples proyectos
* RF-11: Datos:

  * Nombre
  * Apellido
  * Dirección
  * Teléfono
  * Email

---

### 5.3 Gestión de Proyectos

* RF-12: Crear proyectos
* RF-13: Editar proyectos
* RF-14: Eliminar proyectos
* RF-15: Listar proyectos
* RF-16: Asociar proyecto a un cliente
* RF-17: Manejar estados:

  * Pendiente
  * En Proceso
  * Completado
* RF-18: Controlar costo total del proyecto

---

### 5.4 Gestión de Materiales

* RF-19: Registrar materiales
* RF-20: Editar materiales
* RF-21: Eliminar materiales
* RF-22: Listar materiales
* RF-23: Controlar:

  * Nombre
  * Cantidad
  * Precio unitario
  * Imagen

---

### 5.5 Gestión de Entregas

* RF-24: Registrar entregas
* RF-25: Editar entregas
* RF-26: Eliminar entregas
* RF-27: Listar entregas
* RF-28: Asociar entrega a un proyecto
* RF-29: Estados de entrega:

  * Pendiente
  * Entregado

---

## 6. 🔗 Requerimientos de API

El sistema debe exponer endpoints REST:

```http
GET     /api/{entity}
GET     /api/{entity}/{id}
POST    /api/{entity}
PUT     /api/{entity}/{id}
DELETE  /api/{entity}/{id}
```

Entidades:

* carpinter
* client
* project
* material
* delivery

---

## 7. 🗄️ Requerimientos de Base de Datos

* Uso de base de datos en la nube (Supabase)
* Persistencia de todas las entidades
* Relaciones:

  * Cliente → Proyectos
  * Proyecto → Entregas
* Integridad referencial obligatoria

---

## 8. ⚙️ Requerimientos No Funcionales

### 8.1 Rendimiento

* El sistema debe responder en menos de 2 segundos en operaciones estándar

### 8.2 Escalabilidad

* Arquitectura basada en Clean Architecture para facilitar crecimiento

### 8.3 Seguridad

* Validación de datos en backend
* Preparado para futura implementación de autenticación (JWT)

### 8.4 Usabilidad

* Interfaz intuitiva en frontend
* Formularios claros y validaciones visibles

### 8.5 Disponibilidad

* Sistema accesible desde navegador web
* Backend desplegado en servidor accesible públicamente

---

## 9. 🧩 Arquitectura del Sistema

```bash
src/
├── Caspentry_Workshop.Api
├── Caspentry_Workshop.Application
├── Caspentry_Workshop.Domain
├── Caspentry_Workshop.Infrastructure
└── Front
```

* Separación por capas
* Uso de repositorios
* Lógica desacoplada

---

## 10. 🧪 Ejemplo de Uso

### Crear entrega:

```json
{
  "deliveryDate": "2026-04-24T00:00:00",
  "statusDelivery": "Pendiente",
  "projectId": 1
}
```

---

## 11. 📊 Estado actual del sistema

* ✔ Backend funcional (.NET)
* ✔ API REST completa
* ✔ Base de datos en Supabase integrada
* ✔ Frontend funcional desplegado

---

## 12. 🚀 Mejoras futuras

* Implementación de autenticación (JWT)
* Dashboard con métricas
* Sistema de roles
* Notificaciones
* Reportes

---

## 13. 👨‍💻 Autor

Desarrollado por **JoseAngelDev2**

---

## 14. 📌 Conclusión

El sistema **Caspentry Workshop** representa una solución sólida para la digitalización de procesos en talleres de carpintería, permitiendo mejorar la organización, el control de recursos y la eficiencia operativa.
