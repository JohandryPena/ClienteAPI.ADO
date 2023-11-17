using System.Text.Json.Serialization;

namespace Client.Domain.DTOs
{
    public class ClienteDTO
    {

        public int ClienteId { get; set; }
        public Persona? Persona { get; set; }
        public string Contraseña { get; set; }
        public string ImagenBase64 { get; set; } = "";
        public bool Estado { get; set; } = true;
    }
}
