# Back Office Comercio

Este proyecto consiste en una aplicacion web integral diseñada para la gestion de comercios multiproposito. Fue desarrollado como proyecto final para la asignatura Programación III (UTN FRGP).

## Caracteristicas Principales

- Administracion de productos, stock, marcas, categorias, clientes y proveedores.
- Registro de operaciones con actualización automatica de stock.
- Cálculo automatizado de precios de venta basado en el costo de compra y el margen de ganancia configurado.
- Sistema de autenticación con niveles de acceso diferenciados (Administrador y Vendedor).
- Implementación de transacciones y lógica de negocio directamente en el motor de base de datos mediante Stored Procedures.

## Stack Tecnologico

- Lenguaje: C# (.NET Framework)
- Interfaz Web: ASP.NET Web Forms y Bootstrap 5
- Base de Datos: SQL Server
- Arquitectura: Diseño en 3 Capas (Presentación, Negocio y Dominio)
- Herramientas: Git, Visual Studio, ADO.NET

## Arquitectura del Proyecto

1. Capa de Presentación: Interfaz de usuario dinamica construida con Web Forms.
2. Capa de Negocio: Contiene la lógica de validación, servicios de email y acceso a base de datos.
3. Capa de Dominio: Entidades que representan el modelo de datos (Producto, Cliente, Venta, etc.).

### Integridad en Transacciones SQL
Para garantizar la consistencia de la información, el sistema delega las operaciones criticas a la base de datos. Se utilizan Stored Procedures que implementan bloques TRY/CATCH y transacciones SQL, asegurando el descuento de stock y el registro del comprobante.

### Automatizacion de Precios
El sistema automatiza el cálculo del precio de venta final mediante lógica en SQL y C#, aplicando margenes de ganancia sobre el precio de costo actualizado en cada compra.


## Configuración e Instalación

1. Base de Datos:
    - Ejecutar el script COMERCIO_DB.sql ubicado en la carpeta /Database.
    - Opcional: Ejecutar INSERTS_SISTEMA_COMPRAS_VENTAS.sql para datos de prueba.

2. Conexion:
    - Abrir negocio/AccesoDatos.cs.
    - Ajustar el ConnectionString segun tu instancia local de SQL Server (por defecto busca .\SQLEXPRESS).

3. Ejecucion:
    - Abrir TPC-Negocio.sln en Visual Studio.
    - Establecer el proyecto presentacion como proyecto de inicio y ejecutar.

### Capturas del Sistema

 ![](img/venta2.jpeg)
 ![](img/clienteAlta.jpeg)
 ![](img/compraDetalle.jpeg)
 ![](img/perfil.jpeg)
 ![](img/prov.jpeg)

---
## Acerca del Proyecto y el equipo 

Este sistema fue desarrollado como proyecto integrador para la materia **Programación III** de la Tecnicatura Universitaria en Programación (UTN FRGP). El objetivo fue aplicar conocimientos de Programación Orientada a Objetos en un sistema construido de punta a punta.

**Equipo:**
* **Nicolas Zabala** 
* **Ezequiel Benitez** 
* **Ivan Baigorria**
