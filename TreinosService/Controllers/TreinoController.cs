using Microsoft.AspNetCore.Mvc;
using TreinosService.DTOs;
using TreinosService.Services;

namespace TreinosService.Controllers
{
    [ApiController]
    [Route("api/treinos")]
    public class TreinoController : ControllerBase
    {
        private readonly ITreinoService _service;

        // Usando a interface ITreinoService no controlador
        public TreinoController(ITreinoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] TreinoRequestDTO dto)
        {
            try
            {
                // Validação do ModelState
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if (dto == null)
                    return BadRequest("Dados do treino são obrigatórios");
                // Chamando o serviço para criar o treino
                var treino = _service.CriarTreino(dto);
                return CreatedAtAction(nameof(BuscarPorId), new { id = treino.Id }, treino);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Log do erro seria ideal aqui
                Console.WriteLine($"Erro ao criar treino: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var treinos = _service.ListarTreinos();
                return Ok(treinos);
            }
            catch (Exception ex)
            {
                // Log do erro seria ideal aqui
                Console.WriteLine($"Erro ao listar treinos: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("ID deve ser maior que zero");
                var treino = _service.BuscarTreino(id);
                if (treino == null)
                    return NotFound($"Treino com ID {id} não encontrado");
                return Ok(treino);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Log do erro seria ideal aqui
                Console.WriteLine($"Erro ao buscar treino: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("ID deve ser maior que zero");
                var deletado = _service.DeletarTreino(id);  // Agora recebe um bool indicando o sucesso
                if (!deletado)
                    return NotFound($"Treino com ID {id} não encontrado");
                return NoContent();  // Retorna 204 No Content se a exclusão foi bem-sucedida
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Log do erro seria ideal aqui
                Console.WriteLine($"Erro ao deletar treino: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor");
            }
        }
    }
}