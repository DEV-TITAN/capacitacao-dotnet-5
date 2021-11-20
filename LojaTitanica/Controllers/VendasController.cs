using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LojaTitanica.Models;
using LojaTitanica.Services;
using Microsoft.AspNetCore.Mvc;

namespace LojaTitanica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ControllerBase
    {
        public readonly DBService _db;

        public VendasController(DBService service)
        {
            _db = service;
        }

        [HttpPost]
        [Route("CriarVenda")]
        public async Task<IActionResult> CriarVenda(CriarVendaRequest request)
        {
            try 
            {
                int idVenda = await _db.CriarVenda(request.idCliente);
                return Ok(new { idVenda = idVenda });
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet]
        public IActionResult Get() 
        {
            try 
            {
                List<Venda> Vendas = _db.ListarVendas();
                return Ok(Vendas);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("AdicionarItem")]
        public async Task<IActionResult> AdicionarItem(AdicionarItemRequest request)
        {
            try
            {
                Produto produto = _db.ProdutoPorId(request.idProduto);
                Item item = new Item()
                {
                    Produto = produto,
                    Quantidade = request.quantidade
                };
                bool changed = await _db.AdicionarItem(request.idVenda, item); 
                return Ok(changed);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetVendaById(int id)
        {
            try 
            {
                Venda venda = _db.VendaPorId(id);
                return Ok(venda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
