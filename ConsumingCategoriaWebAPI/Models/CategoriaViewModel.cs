using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsumingCategoriaWebAPI.Models
{
    public class CategoriaViewModel
    {
        [Key]
        public int IdCategoria { get; set; }

        [DisplayName("Descripción")]
        public string? Descripcion { get; set; }

        public bool? Estado { get; set; }

        [DisplayName("Fecha de Creación")]
        public DateTime FechaCreacion { get; set; }
    }
}
