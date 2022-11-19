using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorFinanca.Entidades
{
    public class Despesa
    {   
        [Key]
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "O campo precisa ter até {1}")]
        public string NomeDespesa { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DespesaData { get; set; }

        [StringLength(20, ErrorMessage = "O campo precisa ter até {1}")]
        public string Categoria { get; set;}


        [ForeignKey("AplicacaoUsuario")]
        public string DespId { get; set; }

        public virtual AplicacaoUsuario AplicacaoUsuario { get; set; }

    }

  
}