using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaTitanica.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string nome { get; set; }
        public string marca { get; set; }
        public decimal preco { get; set; }
        public int quantidade { get; set; }
    }
}

