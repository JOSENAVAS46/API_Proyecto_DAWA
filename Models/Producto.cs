using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_Proyecto_DAWA.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Categoria Categoria { get; set; }

        public decimal PrecioUnitario { get; set; }
        public int Stock { get; set; }
    }
}
