using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Application.Contratos;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventosService _eventosService;
        public EventosController(IEventosService eventosService)
        {
            _eventosService = eventosService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _eventosService.GetAllEventosAsync(true);
                if(eventos == null){
                    return NotFound("Nenhum evento encontrados.");
                }
                return Ok(eventos);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar recuperar os eventos. erro {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var evento = await _eventosService.GetEventoByIdAsync(id, true);
                if(evento == null){
                    return NotFound("Nenhum evento encontrado.");
                }
                return Ok(evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar recuperar o evento. erro {ex.Message}");
            }
        }

        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                var eventos = await _eventosService.GetAllEventosByTemaAsync(tema, true);
                if(eventos == null){
                    return NotFound("Nenhum evento por tema nao encontrados.");
                }
                return Ok(eventos);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar recuperar os eventos. erro {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model){
            try
            {
                var eventos = await _eventosService.AddEventos(model);
                if(eventos == null){
                    return BadRequest("Erro ao criar evento.");
                }
                return Ok(eventos);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar criar o evento. erro {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model){
            try
            {
                var eventos = await _eventosService.UpdadeEventos(id, model);
                if(eventos == null){
                    return BadRequest("Erro ao atualizar o evento.");
                }
                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar atualizar o evento. Erro: {ex.Message}");
            }
        }
        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete(int id){
            try
            {
                if(await _eventosService.DeleteEventos(id)){
                    return Ok("Evento deletado");
                }else{
                    return BadRequest("Erro ao deleta o evento.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar deleta o evento. Erro: {ex.Message}");
            }
        }
    }
}
