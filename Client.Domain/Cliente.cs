using System.Text.Json.Serialization;

namespace Client.Domain
{
    public class Cliente
    {
       
        public int ClienteId { get; set; }
        public Persona? Persona { get; set; }
        public string Contraseña { get; set; } 
        public byte[] ImagenBase64 { get; set; } = new byte[0];
        public bool Estado { get; set; } = true;
    }
}
