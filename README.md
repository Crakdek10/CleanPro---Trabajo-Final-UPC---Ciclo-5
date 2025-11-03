# CleanPro---Trabajo-Final-UPC---Ciclo-5
Realizado por 3 personas

# 🧼 CleanPro - Sistema de Gestión de Servicios de Saneamiento

**CleanPro** es una aplicación de escritorio desarrollada en **C# con WPF** para optimizar la gestión de servicios de limpieza, desinfección y control ambiental en la empresa **CleanPro Perú**.  
El sistema permite administrar reservas, trabajadores (cleaners), reportes y comprobantes, integrando en una sola herramienta los procesos operativos del área de servicios.

---

## 🏢 Capítulo 1: Presentación

### 🏢 Descripción de la empresa
**CleanPro Perú** es una empresa peruana especializada en saneamiento ambiental, limpieza profesional y servicios generales.  
Además de la venta de productos (desinfectantes, detergentes, alcoholes, insecticidas, etc.), ofrece servicios como:

- 🧴 Desinfección de ambientes  
- 🐀 Control de plagas  
- 💧 Limpieza de reservorios de agua  
- 🧹 Limpieza integral de ambientes  
- ⚙️ Mantenimiento de trampas de grasa y pozos sépticos  
- 🚛 Transporte de residuos  

CleanPro opera de forma virtual, brindando cobertura a todo el país mediante atención digital, y está certificada bajo estándares de calidad como **ISO 9001** e **ISO 14001**.

---

## ⚙️ Capítulo 2: Descripción del sistema

El sistema automatiza los principales procesos del área de **servicios operativos**:

### Procesos automatizados
1. **Recepción y registro de pedidos**  
   - Formulario estructurado para registrar reservas con datos del cliente, tipo de servicio, fecha y hora.  
2. **Asignación de personal**  
   - Asignación manual o filtrada por provincia, servicio y disponibilidad del cleaner.  
3. **Seguimiento del estado del servicio**  
   - Control de estados: pendiente, en proceso, completado, cancelado.  
4. **Registro de observaciones e incidencias**  
   - Permite a los cleaners registrar observaciones en cada reserva.  
5. **Generación de comprobantes QR**  
   - Creación automática de un comprobante con código QR escaneable.  

---

## 🧑‍💼 Capítulo 3: Roles del sistema

### 👨‍💻 Administrador
Accede mediante usuario y contraseña.  
Funciones principales:
- Visualiza **Dashboard** con últimas reservas y reportes.  
- Gestiona **cleaners**: registro, edición, eliminación, filtro por provincia y estado.  
- Gestiona **reservas**: creación, asignación, búsqueda y actualización.  
- Genera **reportes** divididos en tres grupos:
  1. **General de Operaciones:**  
     - Volumen de reservas por mes  
     - Distribución de estados de reservas  
  2. **Análisis de Servicios:**  
     - Popularidad de tipos de servicio  
     - Top 10 departamentos con más reservas  
  3. **Rendimiento de Cleaners:**  
     - Ranking de cleaners  
     - Carga de trabajo por cleaner  

Cada reporte tiene su **tabla, gráfico (barras, pastel o dona)** y filtro por **año**.

---

### 🧹 Cleaner (Empleado)
Accede con su DNI y contraseña.  
Funciones principales:
- Visualiza sus **pendientes** y un **mapa interactivo (Google Maps)**.  
- Consulta su **historial de reservas** realizadas.  
- Revisa su **informe personal**, que incluye:
  - Total de reservas realizadas  
  - Total del mes actual  
  - Gráfico de tipos de trabajo  
  - Sueldo acumulado  
- Edita su **información personal**.  
- Puede **marcar un trabajo como terminado**, generando un comprobante con **código QR** imprimible.

---

## 🧩 Capítulo 4: Arquitectura del sistema

**Tecnología principal:**  
- Lenguaje: `C# (.NET 6)`  
- Interfaz: `Windows Presentation Foundation (WPF)`  
- Base de datos: `SQL Server`  
- Conexión: `ADO.NET / Entity Framework`  
- Gráficos: `OxyPlot / LiveCharts`

**Estructura de clases principales:**
- `CCliente`
- `CCleaner`
- `CServicio`
- `CReserva`
- `CComprobante`
- `CAdministrador`

**Relaciones clave:**
- 1 Cliente → N Reservas  
- 1 Cleaner → N Reservas  
- 1 Servicio → N Reservas  
- 1 Reserva → 0..1 Comprobante  

---

## 🗃️ Capítulo 5: Base de datos

Tablas principales:
| Tabla | Descripción |
|-------|--------------|
| **Cliente** | Registra información de clientes |
| **Cleaner** | Contiene datos del personal operativo |
| **Servicio** | Lista de tipos de servicio |
| **Reserva** | Registra cada solicitud de servicio |
| **Comprobante** | Guarda los comprobantes generados |
| **Administrador** | Contiene credenciales de acceso admin |

---

## 🖥️ Capítulo 6: Interfaz del sistema

### 👨‍💼 Módulo Administrador
- Dashboard general con resumen y gráficos  
- Módulo **Cleaners** con gestión completa de empleados  
- Módulo **Reservas** con listado, filtros y creación  
- Módulo **Reportes** con análisis por año

### 🧹 Módulo Cleaner
- Dashboard con pendientes y mapa interactivo  
- Historial de trabajos realizados  
- Informe general de desempeño  
- Información personal editable  
- Comprobante QR imprimible

---

## 📈 Capítulo 7: Resultados esperados

- Reducción del tiempo de asignación de personal.  
- Control actualizado del estado de servicios.  
- Trazabilidad de todas las reservas y comprobantes.  
- Visualización estadística del rendimiento general.  
- Mejora de la comunicación entre administrador y cleaner.

---

## 👥 Autores

Proyecto desarrollado por estudiantes de **Ingeniería de Sistemas de la Información – UPC (2025)**:

- 👨‍💻 **Alexander Junior Aquino Pérez** – Diseño de interfaz y base de datos  
- 👨‍💻 **Gerardo Manuel Richard Chávez Ayala** – Desarrollo del sistema y flujo de reservas  
- 👨‍💻 **Camilo Alonso Párraga Piñín** – Diseño de reportes y lógica de conexión  

---

## 📚 Referencias

- [CleanPro Perú – Sitio oficial](https://www.cleanpro.com.pe/)  
- [DIGESA – Ministerio de Salud del Perú](http://www.digesa.minsa.gob.pe/)  
- [Bizagi – Automatización de procesos](https://www.bizagi.com/es/plataforma/automation)

---

## 🧾 Licencia
Este proyecto fue desarrollado con fines académicos para la **Universidad Peruana de Ciencias Aplicadas (UPC)**.  
Uso libre con fines educativos, sin fines comerciales.
