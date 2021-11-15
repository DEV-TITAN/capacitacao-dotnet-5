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
    public class ProdutosController : ControllerBase
    {
        public readonly DBService _db;

        public ProdutosController(DBService service)
        {
            _db = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Produto produto)
        {
            try 
            {
                bool changed = await _db.CriarProduto(produto);
                return Ok(changed);
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
                List<Produto> produtos = _db.ListarProdutos();
                return Ok(produtos);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}