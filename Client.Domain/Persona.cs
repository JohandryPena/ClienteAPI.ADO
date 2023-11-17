namespace Client.Domain
{
    public class Persona
    {
        public string Nombre { get; set; } = string.Empty; 
        public string Genero { get; set; } = string.Empty;
		public int Edad { get; set; }
        public int TipoIdentificacion { get; set; }
        public int Identificacion { get; set; }
        public string Direccion { get; set; } = string.Empty;
		public string Telefono { get; set; } = string.Empty;
	}
}
