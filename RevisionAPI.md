# Documentación de la API de Revisión

## Información General
- **Base URL**: `/api/Revision`
- **Autenticación**: Requerida (`[Authorize]`)
- **Formato de Respuesta**: Todas las respuestas están envueltas en un objeto estandarizado `ApiResult`. Las respuestas exitosas devuelven un código HTTP 200 OK.

---

## Endpoints

### 1. Obtener todas las Revisiones
- **URL**: `/api/Revision`
- **Método**: `GET`
- **Parámetros de Consulta (Query)**:
  - `estado` (int, opcional, por defecto 0): Filtrar por estado de la revisión.
  - `id` (int, opcional, por defecto 0): Filtrar por ID de la revisión.
- **Ejemplo Postman**: 
  - Por estado: `GET {{url}}/api/Revision?estado=1`
  - Por ID: `GET {{url}}/api/Revision?id=19`
- **Respuesta JSON**:
```json
{
  "success": true,
  "data": [
    {
      "codigo": "REV-001",
      "nro_orden": "ORD-12345",
      "fecha": "2023-10-27T10:00:00",
      "observaciones": "Revisión general y cambio de aceite.",
      "fecha_ingreso": "2023-10-26T08:00:00",
      "hora_ingreso": "08:00",
      "placa": "ABC-123",
      "cliente": "CLI-001",
      "nombre_cliente": "Juan Perez",
      "tipo_trabajo": "MT01",
      "nombre_tipo_trabajo": "Mantenimiento Preventivo",
      "kilometraje": 50000,
      "tecnico": "TEC-05",
      "nombre_tecnico": "Carlos Ramirez",
      "estado": 1,
      "id": 105
    }
  ]
}
```

### 2. Obtener Checklist de una Revisión
- **URL**: `/api/Revision/{id}/checklist/{idSistema}`
- **Método**: `GET`
- **Parámetros de Ruta**:
  - `id` (int): ID de la revisión.
  - `idSistema` (string): ID del sistema.
- **Ejemplo Postman**: `GET {{url}}/api/Revision/105/checklist/SIS-MOTOR`
- **Respuesta JSON**:
```json
{
  "success": true,
  "data": [
    {
      "id": 105,
      "id_sistema": "SIS-MOTOR",
      "codigo": "CHK-001",
      "observaciones": "Revisión de correas y niveles",
      "estado": 1
    }
  ]
}
```

### 3. Crear una Revisión
- **URL**: `/api/Revision`
- **Método**: `POST`
- **Cuerpo (Body)**: `CreateRevisionRequest`
- **Ejemplo Postman**: `POST {{url}}/api/Revision`
- **Ejemplo JSON Request**:
```json
{
  "nro_orden": "ORD-12346",
  "fecha": "2023-10-27T10:00:00",
  "observaciones": "Revisión inicial",
  "placa": "XYZ-987",
  "cliente": "CLI-002",
  "tipo_trabajo": "MT02",
  "kilometraje": 60000,
  "tecnico": "TEC-05",
  "usuario": "ADMIN",
  "estado": 1,
  "id_sistema": "SIS-MOTOR",
  "detalles": [
    {
      "id_item_taller": 1,
      "falla": false,
      "observacion": "En buen estado",
      "posicion": "Delantera"
    }
  ]
}
```
- **Respuesta JSON**:
```json
{
  "success": true,
  "data": {
    "Id": 106
  }
}
```

### 4. Actualizar una Revisión
- **URL**: `/api/Revision/{id}`
- **Método**: `PUT`
- **Parámetros de Ruta**:
  - `id` (int): ID de la revisión a actualizar.
- **Cuerpo (Body)**: `CreateRevisionRequest`
- **Ejemplo Postman**: `PUT {{url}}/api/Revision/106`
- **Ejemplo JSON Request**:
```json
{
  "nro_orden": "ORD-12346",
  "observaciones": "Revisión actualizada, falla detectada",
  "kilometraje": 60500,
  "estado": 2,
  "detalles": [
    {
      "id_item_taller": 1,
      "falla": true,
      "observacion": "Desgaste detectado",
      "posicion": "Delantera"
    }
  ]
}
```
- **Respuesta JSON**:
```json
{
  "success": true,
  "data": null
}
```

### 5. Anular una Revisión
- **URL**: `/api/Revision/{id}/anular`
- **Método**: `PATCH`
- **Parámetros de Ruta**:
  - `id` (int): ID de la revisión a anular.
- **Ejemplo Postman**: `PATCH {{url}}/api/Revision/106/anular`
- **Respuesta JSON**:
```json
{
  "success": true,
  "data": null
}
```

### 6. Obtener Diagnóstico
- **URL**: `/api/Revision/{id}/diagnostico`
- **Método**: `GET`
- **Parámetros de Ruta**:
  - `id` (int): ID de la revisión.
- **Ejemplo Postman**: `GET {{url}}/api/Revision/105/diagnostico`
- **Respuesta JSON**:
```json
{
  "success": true,
  "data": {
    "id": 105,
    "codigo": "REV-001",
    "solucion": "Cambio de bujías y limpieza de inyectores completada."
  }
}
```

### 7. Insertar/Actualizar (Upsert) Diagnóstico
- **URL**: `/api/Revision/{id}/diagnostico`
- **Método**: `POST`
- **Parámetros de Ruta**:
  - `id` (int): ID de la revisión.
- **Cuerpo (Body)**: `UpsertDiagnosticoRequest`
- **Ejemplo Postman**: `POST {{url}}/api/Revision/105/diagnostico`
- **Ejemplo JSON Request**:
```json
{
  "diag_preliminar": "El motor presenta vibraciones",
  "diag_tecnico": "Soportes de motor desgastados",
  "solucion": "Reemplazo de soportes",
  "usuario": "ADMIN"
}
```
- **Respuesta JSON**:
```json
{
  "success": true,
  "data": null
}
```

### 8. Obtener Diagnóstico para Impresión
- **URL**: `/api/Revision/{id}/diagnostico/impresion`
- **Método**: `GET`
- **Parámetros de Ruta**:
  - `id` (int): ID de la revisión.
- **Ejemplo Postman**: `GET {{url}}/api/Revision/105/diagnostico/impresion`
- **Respuesta JSON**:
```json
{
  "success": true,
  "data": {
    "id": 105,
    "nro_orden": "ORD-12345",
    "cliente": "CLI-001",
    "nombre_cliente": "Juan Perez",
    "vehiculo": "Vehículo Marca Modelo",
    "placa": "ABC-123",
    "kilometraje": 50000,
    "solucion": "Cambio de bujías y limpieza de inyectores completada."
  }
}
```

---

## Modelos de Datos

### CreateRevisionRequest
Estructura enviada para crear o actualizar una revisión:
- `nro_orden` (string)
- `fecha` (string)
- `observaciones` (string)
- `fecha_ingreso` (string)
- `hora_ingreso` (string)
- `fecha_salida` (string)
- `hora_salida` (string)
- `placa` (string)
- `cliente` (string)
- `tipo_trabajo` (string)
- `nivel_combustible` (string)
- `kilometraje` (decimal)
- `tecnico` (string)
- `usuario` (string)
- `estado` (int)
- `id_sistema` (string)
- `detalles` (List<ItemTallerRequest>): Lista de ítems del taller asociados.

### ItemTallerRequest
Detalle de evaluación o ítem de la revisión:
- `id_item_taller` (int)
- `falla` (bool)
- `observacion` (string, opcional)
- `posicion` (string, opcional)

### UpsertDiagnosticoRequest
Estructura para registrar un diagnóstico:
- `diag_preliminar` (string, opcional)
- `diag_tecnico` (string, opcional)
- `solucion` (string, opcional)
- `usuario` (string, opcional)

### RevisionResponse
Objeto principal devuelto en las consultas:
- `codigo` (string)
- `nro_orden` (string)
- `nro_cotiza` (string)
- `fecha` (string)
- `observaciones` (string)
- `fecha_ingreso` (string)
- `hora_ingreso` (string)
- `fecha_salida` (string)
- `hora_salida` (string)
- `placa` (string)
- `cliente` (string)
- `nombre_cliente` (string)
- `tipo_trabajo` (string)
- `nombre_tipo_trabajo` (string)
- `nivel_combustible` (string)
- `kilometraje` (decimal)
- `tecnico` (string)
- `nombre_tecnico` (string)
- `fecha_server` (string)
- `estacion` (string)
- `usuario` (string)
- `nombre_usuario` (string)
- `estado` (int)
- `id` (int)
- `id_sistema` (string)
- `solucion` (string)

### RevisionDetalleResponse
Hereda todas las propiedades de `RevisionResponse`, utilizado para retornar los detalles (checklist) asociados a un sistema particular.
