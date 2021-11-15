namespace LojaTitanica.Models
{
    public class AdicionarItemRequest
    {
        public int idVenda { get; set; }
        public int idProduto { get; set; }
        public int quantidade { get; set; }
    }
}