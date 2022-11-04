//classe que compoe o modelo de domínio
using System.Dynamic;
using System;
using System.ComponentModel.DataAnnotations; //aplica o atributos para gerar as colunas com as config
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorFinanca.Models
{
    public class Despesa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name="Despesa")]
        public string NomeDespesa { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName="decimal(10,2)")]
        public decimal Valor { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime DespesaData { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        public string Categoria { get; set;}

    }

  
}