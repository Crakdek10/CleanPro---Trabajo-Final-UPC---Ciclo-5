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
<img width="942" height="535" alt="image" src="https://github.com/user-attachments/assets/186150e8-eeae-4c2e-9e93-c8a9708bc9bd" />
<img width="949" height="541" alt="image" src="https://github.com/user-attachments/assets/6347d233-ce54-414b-8551-8a2feaab3adc" />

Funciones principales:
- Visualiza **Dashboard** con últimas reservas y reportes.
<img width="1566" height="939" alt="image" src="https://github.com/user-attachments/assets/df844e68-2502-4fa7-8e96-6c8f343c6821" />
  
- Gestiona **cleaners**: registro, edición, eliminación, filtro por provincia y estado.
<img width="1573" height="952" alt="image" src="https://github.com/user-attachments/assets/2af7fb0f-3137-4e2b-8812-4a05aa0b4c5f" />
<img width="1576" height="948" alt="image" src="https://github.com/user-attachments/assets/d91ea093-9a9c-4f47-aeca-294b6543efb7" />
<img width="1580" height="1004" alt="image" src="https://github.com/user-attachments/assets/dd8f410d-12a1-483c-8854-150bd12d5328" />


- Gestiona **reservas**: creación, asignación, búsqueda y actualización.
<img width="1573" height="950" alt="image" src="https://github.com/user-attachments/assets/d53a1e16-9644-4888-b355-478b9142367b" />
<img width="1570" height="946" alt="image" src="https://github.com/user-attachments/assets/7dd81846-ee6d-4803-8aee-89c37039886c" />
<img width="1583" height="996" alt="image" src="https://github.com/user-attachments/assets/22ab3e69-2f84-46de-9903-0dd07ed84da3" />

- Genera **reportes** divididos en tres grupos:
  1. **General de Operaciones:**  
     - Volumen de reservas por mes  
     - Distribución de estados de reservas
<img width="1581" height="999" alt="image" src="https://github.com/user-attachments/assets/87a6c6a4-e9ee-43ce-b9b4-ddb46c1688c4" />
  
  2. **Análisis de Servicios:**  
     - Popularidad de tipos de servicio  
     - Top 10 departamentos con más reservas
<img width="1574" height="995" alt="image" src="https://github.com/user-attachments/assets/e8a40d5d-f4ed-402d-b4eb-8b1adba56aba" />

  3. **Rendimiento de Cleaners:**  
     - Ranking de cleaners  
     - Carga de trabajo por cleaner  
<img width="1578" height="997" alt="image" src="https://github.com/user-attachments/assets/9b0beea3-67d9-4ff0-972c-af017ae2abef" />

Cada reporte tiene su **tabla, gráfico (barras, pastel o dona)** y filtro por **año**.

---

### 🧹 Cleaner (Empleado)
Accede con su DNI y contraseña.  
<img width="942" height="535" alt="image" src="https://github.com/user-attachments/assets/186150e8-eeae-4c2e-9e93-c8a9708bc9bd" />
<img width="945" height="541" alt="image" src="https://github.com/user-attachments/assets/96197ac2-f0bd-44b8-8dd4-0af133cc9ece" />

Funciones principales:
- Visualiza sus **pendientes** y un **mapa interactivo (Google Maps)**.
<img width="1530" height="863" alt="image" src="https://github.com/user-attachments/assets/5fd025b1-6125-4e49-a482-bed11d4af7df" />
  
- Consulta su **historial de reservas** realizadas.
<img width="1528" height="866" alt="image" src="https://github.com/user-attachments/assets/3b1dc88f-c1cd-41b3-a518-0473c30ce783" />
<img width="1528" height="870" alt="image" src="https://github.com/user-attachments/assets/c2028080-04dc-4552-9cb6-c703fdac2c76" />

  
- Revisa su **informe personal**, que incluye:
  - Total de reservas realizadas  
  - Total del mes actual  
  - Gráfico de tipos de trabajo  
  - Sueldo acumulado
<img width="1525" height="868" alt="image" src="https://github.com/user-attachments/assets/2b9a9b59-d4eb-4b63-9b00-bef5612560f4" />

- Edita su **información personal**.
<img width="1525" height="864" alt="image" src="https://github.com/user-attachments/assets/a1db7cef-4d39-43ad-acef-127dedf59ffc" />
  
- Puede **marcar un trabajo como terminado**, generando un comprobante con **código QR** imprimible.
<img width="1527" height="868" alt="image" src="https://github.com/user-attachments/assets/9bfd2ba4-c0e8-45a6-bcc8-67177f98f2f6" />
<img width="1527" height="865" alt="image" src="https://github.com/user-attachments/assets/c7cbf9b4-6bc4-4d50-a877-b70f7a546533" />
<img width="1528" height="870" alt="image" src="https://github.com/user-attachments/assets/55377ba2-fc15-43d5-8ec3-dbe656906e67" />
<img width="590" height="593" alt="image" src="https://github.com/user-attachments/assets/4866b6d8-f856-429d-b654-d5ea49ed6148" />
<img width="1532" height="865" alt="image" src="https://github.com/user-attachments/assets/767bf05d-889d-4334-a345-c18f2f36699a" />


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
