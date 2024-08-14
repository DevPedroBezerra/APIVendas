using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static APIVendas.Models.ProdutosModel;
using static APIVendas.Models.VendedoresModel;

namespace APIVendas.Models
{
    public class VendasModel
    {
        
         [Key]
         public int Id { get; set; }

         [Required]
         [Column(TypeName = "decimal(17,2)")]
         public decimal Preco {  get; set; }

         [Required][Column(TypeName = "datetime")] 
         public DateTime Data_Venda {  get; set; }

         [ForeignKey("Vendedor")]
         public int VendedorId { get; set; }

         [JsonIgnore]
         public VendedoresModel Vendedor { get; set; }

         [ForeignKey("Produto")]
         public int ProdutoId { get; set; }

         [JsonIgnore]
         public ProdutosModel Produto { get; set; }

        
    }
}
