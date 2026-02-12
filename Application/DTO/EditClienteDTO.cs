namespace WorkShopGL.Application.DTO
{
    public class EditClienteDTO
    {
        public string Codigo { get; set; }
        public string Nit { get; set; }              
        public string TipoDocumento { get; set; }
        public int TipoPersona { get; set; }
        public string PrimerNombre { get; set; }     
        public string SegundoNombre { get; set; }    
        public string PrimerApellido { get; set; }  
        public string SegundoApellido { get; set; } 
        public string Direccion { get; set; }        
        public string Telefono { get; set; }         
        public string Email { get; set; }            
        public string Celular { get; set; }          
        public string CodigoCiudad { get; set; }     
        public string CodigoPais { get; set; }       
    }
}
