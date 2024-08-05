using System.ComponentModel.DataAnnotations;

namespace ClienteWebAPI.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string? TipoDocumento { get; set; }
        public string? Documento { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
