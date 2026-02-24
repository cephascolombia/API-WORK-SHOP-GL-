# Documentación API Técnicos

Esta API permite la gestión integral del personal técnico del taller, incluyendo operaciones de creación, actualización, eliminación y consulta paginada.

## Información General

- **Base URL:** `/api/tecnico`
- **Autenticación:** Requerida (Bearer Token) en todos los endpoints.
- **Formato de Respuesta:** Las respuestas están envueltas en un objeto `ApiResult`.

---

## 1. Endpoints

### 1.1 Crear Técnico
Crea un nuevo registro de técnico en el sistema.

- **Endpoint:** POST `/api/tecnico/create`
- **Request Body:**
```json
{
  "nit": "123456789",
  "tipo_documento": "CC",
  "tipo_persona": 1,
  "primer_nombre": "JUAN",
  "segundo_nombre": "CARLOS",
  "primer_apellido": "PEREZ",
  "segundo_apellido": "GOMEZ",
  "direccion": "CALLE 123 # 45-67",
  "telefono": "1234567",
  "email": "juan.perez@example.com",
  "celular": "3001234567",
  "codigo_ciudad": "05001",
  "nombre_ciudad": "MEDELLIN",
  "codigo_pais": "COL",
  "nombre_pais": "COLOMBIA"
}
```
- **Respuesta Exitosa (200 OK):**
```json
{
  "success": true,
  "data": {
    "id": "TEC001"
  },
  "message": null
}
```

### 1.2 Actualizar Técnico
Actualiza la información de un técnico existente.

- **Endpoint:** PUT `/api/tecnico/update`
- **Request Body:**
```json
{
  "codigo_tecnico": "TEC001",
  "nit": "123456789",
  "tipo_documento": "CC",
  "tipo_persona": 1,
  "primer_nombre": "JUAN",
  "segundo_nombre": "CARLOS",
  "primer_apellido": "PEREZ",
  "segundo_apellido": "GOMEZ",
  "direccion": "AVENIDA SIEMPRE VIVA 123",
  "telefono": "7654321",
  "email": "juan.perez.updated@example.com",
  "celular": "3109876543",
  "codigo_ciudad": "05001",
  "nombre_ciudad": "MEDELLIN",
  "codigo_pais": "COL",
  "nombre_pais": "COLOMBIA"
}
```
- **Respuesta Exitosa (200 OK):**
```json
{
  "success": true,
  "data": {
    "id": "TEC001"
  },
  "message": null
}
```

### 1.3 Eliminar Técnico
Elimina (lógicamente) un técnico del sistema.

- **Endpoint:** DELETE `/api/tecnico/delete/{codigoTecnico}`
- **Parámetros de Ruta:**
    - `codigoTecnico` (string): Código único del técnico.
- **Respuesta Exitosa (200 OK):**
```json
{
  "success": true,
  "data": {
    "id": "TEC001"
  },
  "message": null
}
```

### 1.4 Obtener Todos los Técnicos (Paginado)
Consulta la lista de técnicos con soporte para búsqueda y paginación.

- **Endpoint:** GET `/api/tecnico/get-all`
- **Query Parameters:**
    - `Busqueda` (string, opcional): Filtra por nombre o cédula.
    - `Pagina` (int, opcional, default: 1): Número de página.
    - `RegistrosXPag` (int, opcional, default: 10): Tamaño de la página.
- **Respuesta Exitosa (200 OK):**
```json
{
  "success": true,
  "data": {
    "items": [
      {
        "cedula": "123456789",
        "codigo": "TEC001",
        "nombre": "JUAN CARLOS PEREZ GOMEZ",
        "direccion": "CALLE 123",
        "celular": "3001234567",
        "email": "juan@example.com",
        "ciudad": "MEDELLIN",
        "pais": "COLOMBIA",
        "totalRegistros": 1,
        "totalPaginas": 1
      }
    ],
    "paginaActual": 1,
    "registrosXPagina": 10,
    "totalRegistros": 1,
    "totalPaginas": 1
  },
  "message": null
}
```

---

## 2. Modelos de Datos

### 2.1 TecnicoBusquedaDTO (Objeto en `items`)
| Propiedad | Tipo | Descripción |
| :--- | :--- | :--- |
| `cedula` | string | NIT o documento de identidad |
| `codigo` | string | Código interno del técnico |
| `nombre` | string | Nombre completo concatenado |
| `direccion` | string | Dirección de residencia |
| `celular` | string | Número de teléfono móvil |
| `email` | string | Correo electrónico |
| `ciudad` | string | Nombre de la ciudad |
| `pais` | string | Nombre del país |

