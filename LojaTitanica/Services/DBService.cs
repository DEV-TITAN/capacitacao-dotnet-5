using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaTitanica.Data;
using LojaTitanica.Enumerators;
using LojaTitanica.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaTitanica.Services
{
    public class DBService
    {
        private readonly MySQLContext _db;

        public DBService(MySQLContext context)
        {
            _db = context;
        }

        public async Task<bool> CriarCliente(Cliente cliente)
        {
            _db.Add<Cliente>(cliente);
            int changes = await _db.SaveChangesAsync();
            if (changes >= 1)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CriarProduto(Produto produto)
        {
            _db.Add<Produto>(produto);
            int changes = await _db.SaveChangesAsync();
            if (changes >= 1)
            {
                return true;
            }
            return false;
        }

        public List<Produto> ListarProdutos()
        {
            return _db.Produtos.ToList<Produto>();
        }

        public async Task<int> CriarVenda(int idCliente)
        {
            Cliente cliente = _db.Clientes.FirstOrDefault<Cliente>(c => c.id == idCliente);
            if (cliente == null) 
            {
                throw new ApplicationException("Cliente não encontrado!");
            }
            Venda venda = new Venda()
            {
                Cliente = cliente,
                Items = new List<Item>(),
                status = StatusVenda.VendaAberta,
                ValorTotal = 0.0m
            };
            _db.Add<Venda>(venda);
            await _db.SaveChangesAsync();
            return venda.id;
        }

        public List<Venda> ListarVendas()
        {
            return _db.Vendas
                    .Include(venda => venda.Cliente)
                    .Include(venda => venda.Items)
                    .ThenInclude(item => item.Produto)
                    .ToList<Venda>();
        }

        public async Task<bool> AdicionarItem(int idVenda, Item item)
        {
            Venda venda = _db.Vendas.FirstOrDefault<Venda>(venda => venda.id == idVenda);
            if (venda == null) {
                throw new ApplicationException("Venda não encontrada.");
            }
            if (venda.Items == null) {
                List<Item> items = new List<Item>();
                venda.Items = items;
            }
            venda.Items.Add(item);
            venda.ValorTotal += item.Produto.Preco * item.Quantidade;   
            _db.Update<Venda>(venda);
            int changes = await _db.SaveChangesAsync();
            if (changes >= 1)
            {
                return true;
            }     
            return false;
        }

        public Produto ProdutoPorId(int idProduto)
        {
            return _db.Produtos.FirstOrDefault<Produto>(produto => produto.id == idProduto);
        }

        public Venda VendaPorId(int idVenda)
        {
            return _db.Vendas
                    .Include(venda => venda.Cliente)
                    .Include(venda => venda.Items)
                    .ThenInclude(item => item.Produto)
                    .FirstOrDefault<Venda>(venda => venda.id == idVenda);
        }
    }
}