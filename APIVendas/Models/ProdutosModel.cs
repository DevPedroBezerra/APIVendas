using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace APIVendas.Models
{
    public class ProdutosModel
    {
        public class Produto
        {
           [Key] public int Id { get; set; }
           [Required][Column(TypeName = "varchar(45)")] public string Nome { get; set; }
           [Required] public int Estoque { get; set; }
           [Column(TypeName = "varchar(255)")] public string Descricao { get; set; }    
           [Required][Column(TypeName = "decimal(18,2)")] public decimal Preco { get; set; }              
           [Column(TypeName = "datetime")] public DateTime DataCadastro { get; set; }
           
           
           
            
        }
    }
}
