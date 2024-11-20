# PruebaCoink
# Proyecto: Gestión de Usuarios

Este proyecto es una API REST desarrollada utilizando **Clean Architecture** para gestionar usuarios. La solución incluye funcionalidades como crear, listar, actualizar y eliminar usuarios, con un enfoque desacoplado y aplicando principios de diseño como DI (Inyección de Dependencias), IoC y Repository Pattern.

---

## Tecnologías utilizadas

- **.NET 8**
- **PostgreSQL 15**
- **FluentValidation**: Validación de datos de entrada.
- **Swagger**: Documentación interactiva de API.
- **HealthChecks**: Monitoreo de la salud del sistema.
- **Docker**: Contenerización (opcional).

---

## Estructura del Proyecto

El proyecto sigue la arquitectura en capas **Clean Architecture**, organizada de la siguiente manera:

├── Coink.Application
	│ 
	├── Interfaces
	│ 
	├── IoC
	│ 
	├── Services
	│
├── Coink.Domain
	│ 
	├── Entities
	│ 
	├── ValueObjects
	│
├── Coink.Infrastructure
	│ 
	├── Data
	│ 
	├── IoC
	│ 
	├── Repository
	│
├── Coink.Presentation
	│ 
	├── Controllers
	│ 
	├── IoC

### Descripción de Capas
1. **Coink.Application**: Contiene la lógica de negocio y servicios. Es responsable de orquestar la interacción entre las capas de dominio e infraestructura.
2. **Coink.Domain**: Define las entidades y reglas de negocio. Es la capa central y no depende de otras.
3. **Coink.Infrastructure**: Implementa detalles técnicos como acceso a datos (Repository) y configuración de servicios.
4. **Coink.Presentation**: Expone los endpoints de la API y maneja la entrada/salida de datos.

---

## Requisitos Previos

1. **Software necesario**:
   - .NET SDK 8 (puedes descargarlo de [aquí](https://dotnet.microsoft.com/en-us/download)).
   - PostgreSQL 15.
   - Docker (opcional, para contenerización).

2. **Configuración del entorno**:
   - Configurar las siguientes variables de entorno:
     - `DbCredentials:PostgreSql`: Cadena de conexión a PostgreSQL.
   - Asegúrate de que PostgreSQL esté en ejecución y que tengas creada una base de datos.

3. **Dependencias del proyecto**:
   ```bash
   dotnet restore
   
---

## Ejecución Local
```bash
   git clone https://github.com/closterdev/PruebaCoink.git
   cd proyecto

CREATE DATABASE dbcoink;
\c gestion_usuarios;
-- Agregar aquí los scripts de creación de tablas y SP.

---

Despliegue en Producción
Usando Docker

dotnet ef database update

dotnet run --project Coink.Presentation

URL: http://localhost:5000/swagger

docker build -t gestion-usuarios:1.0 .

docker run -d -p 5000:80 --env-file .env gestion-usuarios:1.0

---

Manual (Sin Docker)

dotnet publish -c Release -o /var/www/gestion-usuarios

---

Endpoints de la API
Usuarios
GET /api/users - Listar todos los usuarios.
POST /api/users - Crear un usuario.
PUT /api/users/{id} - Actualizar un usuario.
DELETE /api/users/{id} - Eliminar un usuario.
Salud del sistema
GET /health - Verificar el estado del sistema.

---

Pruebas

dotnet test

---

Solución de Problemas
Error: "Database connection failed":

Verifica que PostgreSQL está ejecutándose y la cadena de conexión es correcta.
Error: "Cannot bind to port 5000":

Asegúrate de que el puerto no está en uso o cambia el puerto en el archivo launchSettings.json.
Error: "Health check failed":

Asegúrate de que la base de datos está activa y accesible.

---

Créditos
Proyecto desarrollado por [Tu Nombre].
Contacto: tuemail@ejemplo.com
Repositorio: GitHub