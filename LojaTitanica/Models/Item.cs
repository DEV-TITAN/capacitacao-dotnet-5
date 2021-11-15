namespace LojaTitanica.Models
{
    public class Item
    {
        public int id { get; set; }
        public Produto produto { get; set; }
        public int quantidade { get; set; }
    }
}