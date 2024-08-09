using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Tracing;
using System.Text.Json.Serialization;
using static APIVendas.Models.VendedoresModel;

namespace APIVendas.Models
{
    public class DepartamentosModel
    {
        public class Departamento 
        {
        [Key]
        public int Id { get; set; }
        [Required][Column(TypeName = "varchar(45)")] public string Nome { get; set; }
        [Column(TypeName = "varchar(45)")] public string Descricao { get; set; }
         
         ICollection<Vendedor> Vendedores { get; set; }

        }
    }
}
