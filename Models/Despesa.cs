//classe que compoe o modelo de domínio
using System.Dynamic;
using System;
using System.ComponentModel.DataAnnotations; //aplica o atributos para gerar as colunas com as config
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorFinanca.Models
{
    public class Despesa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome da despesa")]
        public string NomeDespesa { get; set; }

        [Required(ErrorMessage = "Digite o valor da despesa")]
        public decimal Valor { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Digite a data da despesa")]
        public DateTime DespesaData { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Informe a Catgoria")]
        public string Categoria { get; set;}

    }

  
}