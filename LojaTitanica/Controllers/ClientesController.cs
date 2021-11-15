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
    public class ClientesController : ControllerBase
    {
        public readonly DBService _db;

        public ClientesController(DBService service)
        {
            _db = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente Cliente)
        {
            try 
            {
                bool changed = await _db.CriarCliente(Cliente);
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
                List<Cliente> Clientes = _db.ListarClientes();
                return Ok(Clientes);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}