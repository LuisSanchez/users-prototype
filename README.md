# Microservicio de Usuarios

Este repositorio contiene el Microservicio de Usuarios, que es parte de un sistema más grande diseñado para gestionar una plataforma de subastas en tiempo real. El sistema está construido utilizando una arquitectura de microservicios, con cada microservicio responsable de un dominio específico.

## Tabla de Contenidos

1. [Introducción](#introducción)
2. [Descripción General de los Microservicios](#descripción-general-de-los-microservicios)
    - [Microservicio de Usuarios](#microservicio-de-usuarios)
    - [Microservicio de Subastas](#microservicio-de-subastas)
    - [Microservicio de Pagos](#microservicio-de-pagos)
    - [Microservicio de Productos](#microservicio-de-productos)
    - [Microservicio de Reclamos y Disputas](#microservicio-de-reclamos-y-disputas)
    - [Microservicio de Reportes](#microservicio-de-reportes)
    - [Microservicio de Notificaciones](#microservicio-de-notificaciones)
    - [Microservicio de Autenticación y Autorización](#microservicio-de-autenticación-y-autorización)
3. [Stack Tecnológico](#stack-tecnológico)
4. [Comenzando](#comenzando)
5. [Contribuyendo](#contribuyendo)
6. [Licencia](#licencia)

## Introducción

La plataforma de subastas es un sistema distribuido que permite a los usuarios participar en subastas en tiempo real. El sistema está compuesto por varios microservicios, cada uno responsable de una funcionalidad específica. Este repositorio se centra en el Microservicio de Usuarios, que gestiona las operaciones relacionadas con los usuarios, como el registro, la autenticación y la gestión de perfiles.

## Descripción General de los Microservicios

### Microservicio de Usuarios

El Microservicio de Usuarios maneja todas las operaciones relacionadas con los usuarios, incluyendo:
- Registro e autenticación de usuarios.
- Gestión de perfiles.
- Gestión de roles y permisos.
- Recuperación y restablecimiento de contraseñas.

### Microservicio de Subastas

El Microservicio de Subastas gestiona la creación, edición y eliminación de subastas. También maneja las pujas en tiempo real y la finalización de las subastas. Las características clave incluyen:
- Creación y gestión de subastas.
- Pujas en tiempo real utilizando WebSockets.
- Notificación de ganadores y finalización de subastas.

### Microservicio de Pagos

El Microservicio de Pagos es responsable de procesar los pagos relacionados con las subastas. Incluye:
- Manejo de transacciones de pago.
- Gestión de métodos de pago.
- Cancelación automática de subastas si los pagos no se reciben dentro de un tiempo especificado.

### Microservicio de Productos

El Microservicio de Productos gestiona los productos disponibles para subasta. Incluye:
- Registro y edición de productos.
- Gestión de inventario de productos.
- Provisión de detalles de productos para subastas.

### Microservicio de Reclamos y Disputas

El Microservicio de Reclamos y Disputas maneja la gestión de reclamos y disputas relacionadas con subastas y productos. Incluye:
- Permitir a los usuarios enviar reclamos.
- Revisión y resolución de disputas.
- Notificación a los usuarios sobre el estado de sus reclamos.

### Microservicio de Reportes

El Microservicio de Reportes genera varios informes relacionados con subastas, pagos y actividades de los usuarios. Incluye:
- Generación de informes sobre el rendimiento de las subastas.
- Provisión de informes sobre actividades de los usuarios y pagos.
- Exportación de informes en formatos como PDF y Excel.

### Microservicio de Notificaciones

El Microservicio de Notificaciones es responsable de enviar notificaciones a los usuarios en tiempo real. Incluye:
- Envío de notificaciones por correo electrónico.
- Provisión de actualizaciones en tiempo real utilizando WebSockets.
- Gestión de preferencias de notificaciones.

### Microservicio de Autenticación y Autorización

El Microservicio de Autenticación y Autorización gestiona la autenticación y autorización de los usuarios. Incluye:
- Manejo de inicio de sesión y registro de usuarios.
- Gestión de roles y permisos.
- Integración con Keycloak para la gestión de identidades y accesos.

## Stack Tecnológico

El proyecto utiliza las siguientes tecnologías:
- **Lenguaje de Programación**: C#
- **Framework**: .NET Core 8
- **Arquitectura**: Arquitectura Hexagonal, Microservicios
- **Base de Datos**: PostgreSQL, MongoDB
- **Broker de Mensajes**: RabbitMQ
- **Tareas en Segundo Plano**: Hangfire
- **Comunicación en Tiempo Real**: WebSockets
- **Autenticación**: Keycloak
- **Frontend**: React, React Native
- **API Gateway**: Yarp
- **Almacenamiento**: Firebase (Storage + Messaging)
- **Gestión de Estados**: MassTransit SAGA

## Comenzando

Para comenzar con el Microservicio de Usuarios, sigue estos pasos:

1. **Clonar el Repositorio**:
   ```bash
   git clone <url-del-repositorio>
   cd UserMicroservice
   ```

2. **Instalar Dependencias**:
   ```bash
   dotnet restore
   ```

3. **Construir el Proyecto**:
   ```bash
   dotnet build
   ```

4. **Ejecutar la Aplicación**:
   ```bash
   dotnet run
   ```

5. **Configurar Variables de Entorno**:
   - Asegúrate de tener las variables de entorno necesarias configuradas para las conexiones a la base de datos, servicios de correo electrónico y otras dependencias externas.

## Contribuyendo

¡Las contribuciones son bienvenidas! Por favor, sigue estos pasos para contribuir:
1. Haz un fork del repositorio.
2. Crea una nueva rama para tu característica o corrección de errores.
3. Realiza tus cambios con un mensaje claro y conciso.
4. Haz push de tu rama a tu fork.
5. Crea una solicitud de extracción (pull request).

## Licencia

Este proyecto está licenciado bajo la Licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más detalles.
