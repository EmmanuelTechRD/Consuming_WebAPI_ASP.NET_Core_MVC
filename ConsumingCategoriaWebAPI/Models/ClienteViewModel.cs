using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsumingCategoriaWebAPI.Models
{
    public class ClienteViewModel
    {
        [Key]
        public int IdCliente { get; set; }

        [DisplayName("Tipo de Documento")]
        public string? TipoDocumento { get; set; }
        public string? Documento { get; set; }

        [DisplayName("Nombre Completo")]
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public bool? Estado { get; set; }

        [DisplayName("Fecha de Creación")]
        public DateTime? FechaCreacion { get; set; }
    }
}
