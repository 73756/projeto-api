using Exo.WebApi.Repositories;
using Exo.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly ProjetoRepository _repo;

        public ProjetosController(ProjetoRepository repo)
        {
            _repo = repo;
        }

        // 🔹 GET - Listar todos
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var projetos = _repo.Listar();

                if (projetos == null || !projetos.Any())
                    return NotFound(new { mensagem = "Nenhum projeto encontrado." });

                return Ok(projetos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao listar projetos.", erro = ex.Message });
            }
        }

        // 🔹 POST - Cadastrar
        [HttpPost]
        public IActionResult Cadastrar(Projeto novoProjeto)
        {
            try
            {
                if (string.IsNullOrEmpty(novoProjeto.NomeDoProjeto) || string.IsNullOrEmpty(novoProjeto.Area))
                    return BadRequest(new { mensagem = "Os campos 'NomeDoProjeto' e 'Area' são obrigatórios." });

                _repo.Cadastrar(novoProjeto);
                return StatusCode(201, new { mensagem = "Projeto cadastrado com sucesso!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao cadastrar o projeto.", erro = ex.Message });
            }
        }

        // 🔹 PUT - Atualizar
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Projeto projetoAtualizado)
        {
            try
            {
                _repo.Atualizar(id, projetoAtualizado);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao atualizar o projeto.", erro = ex.Message });
            }
        }

        // 🔹 DELETE - Excluir
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _repo.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao excluir o projeto.", erro = ex.Message });
            }
        }
    }
}