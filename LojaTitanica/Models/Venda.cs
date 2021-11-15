using System.Collections.Generic;
using System.Linq;
using LojaTitanica.Enumerators;

namespace LojaTitanica.Models
{
    public class Venda
    {
        public int id { get; set; }
        public int idCliente { get; set; }
        public decimal valorTotal { get; set; }
        public StatusVenda status { get; set; }
        
    }
}