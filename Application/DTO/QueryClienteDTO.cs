namespace WorkShopGL.Application.DTO
{
    public class QueryClienteDTO
    {
        public string Codigo { get; set; }
        public string Nit { get; set; }                 
        public string Tipo_documento { get; set; }      
        public string Nombre_completo { get; set; }     
        public string Primer_nombre { get; set; }       
        public string Segundo_nombre { get; set; }      
        public string Primer_apellido { get; set; }     
        public string Segundo_apellido { get; set; }    
        public string Direccion { get; set; }           
        public string Telefono { get; set; }            
        public string Email { get; set; }               
        public string Celular { get; set; }             
        public string Codigo_ciudad { get; set; }       
        public string Nombre_ciudad { get; set; }       
        public string Codigo_pais { get; set; }         
        public string Nombre_pais { get; set; }         
        public DateTime Fecha_registro { get; set; }    
        public int TotalRecords { get; set; }
    }
}
