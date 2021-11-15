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
        public readonly MySQLContext _db;

        public DBService(MySQLContext context)
        {
            _db = context;
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

        public Produto ProdutoPorId(int idProduto)
        {
            return _db.Produtos.FirstOrDefault<Produto>(p => p.id == idProduto);
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

        public List<Cliente> ListarClientes()
        {
            return _db.Clientes.ToList<Cliente>();
        }

        public async Task<int> CriarVenda(int idCliente)
        {
            Cliente cliente = _db.Clientes.FirstOrDefault<Cliente>(c => c.id == idCliente);
            Venda venda = new Venda()
            {
                cliente = cliente,
                items = new List<Item>(),
                status = StatusVenda.vendaAberta,
                valorTotal = 0.0m
            };
            _db.Add<Venda>(venda);
            await _db.SaveChangesAsync();
            return venda.id;
        }

        public List<Venda> ListarVendas()
        {
            return _db.Vendas.Include(venda => venda.cliente)
                    .Include(venda => venda.items)
                    .ThenInclude(item => item.produto)
                    .ToList<Venda>();
        }

        public async Task<bool> AdicionarItem(int idVenda, Item item)
        {
            Venda venda = _db.Vendas.Include(venda => venda.items).FirstOrDefault<Venda>(venda => venda.id == idVenda);
            if (venda == null) {
                throw new ApplicationException("Venda não encontrada.");
            }
            if (venda.items == null) {
                List<Item> items = new List<Item>();
                venda.items = items;
            }
            venda.items.Add(item);
            venda.valorTotal += item.produto.preco * item.quantidade;
            _db.Update<Venda>(venda);
            int changes = await _db.SaveChangesAsync();
            if (changes >= 1) 
            {
                return true;
            }
            return false;
        }
    }
}