# App Interfaces  

## 📌 Descripción  

**App Interfaces** es una aplicación de escritorio desarrollada en **C# con Windows Forms**, diseñada para la gestión de un catálogo de videojuegos. La aplicación cuenta con autenticación de usuarios y funcionalidades diferenciadas para **usuarios normales** y **administradores**.  

Los usuarios pueden explorar el catálogo, gestionar su biblioteca personal y realizar compras, mientras que los administradores tienen acceso a herramientas avanzadas de gestión de usuarios y videojuegos.  

## 🚀 Características Principales  

✅ **Autenticación de usuarios** (Inicio de sesión y registro).  
✅ **Catálogo de videojuegos** accesible para todos los usuarios.  
✅ **Biblioteca personal**, donde los usuarios pueden gestionar sus juegos adquiridos.  
✅ **Sistema de cesta de compras** para la adquisición de videojuegos.  
✅ **Panel de administración** con gestión de usuarios.  
✅ **Editor de videojuegos** para administradores, permitiendo la creación y edición de juegos.  

## 📂 Estructura del Proyecto  

El proyecto está organizado en diferentes formularios y controles clave:  

| Archivo                        | Descripción |
|--------------------------------|------------|
| `ventana/mainFrom.cs`         | Ventana principal con opciones de login y registro. |
| `ventana/LoginForm.cs`        | Formulario de inicio de sesión. |
| `ventana/RegisterForm.cs`     | Formulario de registro de nuevos usuarios. |
| `ventana/ventanaAdminForm.cs` | Panel de administración para gestión de usuarios y videojuegos. |
| `ventana/EditorVideojuegoForm.cs` | Editor de videojuegos exclusivo para administradores. |
| `ventana/CatalogoControl.cs`  | Control para mostrar el catálogo de juegos. |
| `ventana/BibliotecaControl.cs` | Módulo de gestión de la biblioteca personal del usuario. |
| `ventana/CestaControl.cs`     | Control del carrito de compras. |

## 🛠️ Requisitos Técnicos  

Para ejecutar correctamente el proyecto, asegúrate de contar con los siguientes requisitos:  

- **Visual Studio** (versión recomendada: 2019 o superior).  
- **.NET Framework** (versión recomendada: 4.7.2 o superior).  
- **MySQL** como sistema de gestión de bases de datos.  

## 🗄️ Base de Datos  

La aplicación utiliza una base de datos MySQL estructurada en varias tablas principales:  

| Tabla      | Descripción |
|-----------|------------|
| `users`   | Almacena la información de los usuarios registrados. |
| `biblioteca` | Gestiona los juegos adquiridos por cada usuario. |
| `videojuegos` | Contiene la información de los videojuegos disponibles en el catálogo. |
| `compras` | Registra las transacciones de los usuarios. |

## 👥 Tipos de Usuario  

### 👤 **Usuario Normal**  
✔️ Acceso al catálogo de juegos.  
✔️ Gestión de su biblioteca personal.  
✔️ Realización de compras a través de la cesta.  

### 🔑 **Administrador**  
✔️ Gestión de usuarios registrados.  
✔️ Creación y edición de videojuegos.  
✔️ Control total del sistema.  

## 📜 Licencia  

Este proyecto se distribuye bajo la [Licencia MIT](License.mit). Consulta el archivo para más detalles.   

---  

📩 **Contacto:** Para dudas o sugerencias, puedes escribir a [aacal666.social@gmail.com].  
