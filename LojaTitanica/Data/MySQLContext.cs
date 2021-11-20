using LojaTitanica.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaTitanica.Data
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) {}

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }  
        public DbSet<Item> Items { get; set; }
        public DbSet<Venda> Vendas { get; set; }
    }
}