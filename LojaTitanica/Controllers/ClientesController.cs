using System;
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
        private readonly DBService _db;

        public ClientesController(DBService service)
        {
            _db = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente cliente)
        {
            try
            {
                bool changed = await _db.CriarCliente(cliente);
                return Ok(changed);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    } 
}