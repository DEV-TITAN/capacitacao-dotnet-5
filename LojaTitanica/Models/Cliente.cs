using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaTitanica.Models
{
    public class Cliente
    {
        [Key]
	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set ;}
        public string Nome { get; set; }

    }
}