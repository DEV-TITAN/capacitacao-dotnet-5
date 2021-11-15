using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LojaTitanica.Enumerators;

namespace LojaTitanica.Models
{
    public class Venda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public Cliente cliente { get; set; }
        public decimal valorTotal { get; set; }
        public List<Item> items { get; set; }
        public StatusVenda status { get; set; }
        
    }
}