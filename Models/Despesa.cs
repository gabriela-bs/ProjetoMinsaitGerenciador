//classe que compoe o modelo de domínio
using System.ComponentModel.DataAnnotations; //aplica o atributos para gerar as colunas com as config
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorFinanca.Models
{
    public class Despesa
    {   
        [Key]
        public int IdDespesa { get; set; }

        [StringLength(50, ErrorMessage = "O campo precisa ter até {1}")]
        public string NomeDespesa { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DespesaData { get; set; } = DateTime.Now;

        [StringLength(20, ErrorMessage = "O campo precisa ter até {1}")]
        public string Categoria { get; set;}


    }

  
}