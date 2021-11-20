using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaTitanica.Models
{
    public class Item
    {
        [Key]
	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
    }
}