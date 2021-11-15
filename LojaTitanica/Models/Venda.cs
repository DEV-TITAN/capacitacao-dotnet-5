using System.Collections.Generic;
using System.Linq;

namespace LojaTitanica.Models
{
    public class Venda
    {
        public int id { get; set; }
        public int idCliente { get; set; }
        public List<Produto> produtos { get; set; }
        public decimal valorTotal { get; set; }
        
    }
}