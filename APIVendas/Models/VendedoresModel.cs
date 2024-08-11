using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text.Json.Serialization;
using static APIVendas.Models.DepartamentosModel;

namespace APIVendas.Models
{
    public class VendedoresModel 
    {
        
      
            [Key] public int Id { get; set; }
            [Required][Column(TypeName = "varchar(45)")]
            public string Nome { get; set; }
            [Required][Column(TypeName = "varchar(45)")]
            public string Sexo { get; set; }
            [Required]
            [Column(TypeName = "datetime")]
            public DateTime Data_Nascimento { get; set; }
            [Required]
            [Column(TypeName = "datetime")]
            public DateTime Data_Contratacao { get; set; } 

            [Required][EmailAddress][MaxLength(255)] 
            public string Email { get; set; }

            [MaxLength(20)] 
            public string Telefone { get; set; }

            [MaxLength(255)] 
            public string Endereco { get; set; }

            [MaxLength(100)] 
            public string CEP { get; set; }

            [MaxLength(100)] 
            public string Pais { get; set; }

            [MaxLength(100)] 
            public string Cidade { get; set; }

            [MaxLength(100)] 
            public string Estado { get; set; }

            [ForeignKey("Departamento")]
            public int DepartamentoId { get; set; }
            [JsonIgnore]
            public DepartamentosModel Departamento { get; set; }
    

    }
}
