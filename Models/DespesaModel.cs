using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorFinanca.Models
{
    public class DespesaModel
    {   
        public int Id { get; set; }
        public string NomeDespesa { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }
        public DateTime DespesaData { get; set; }
        public string Categoria { get; set;}

        public string DespId { get; set; }

    }

  
}