using ExoApi.Interfaces;
using ExoApi.Models;
using ExoApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoRepository _projetoRepository;
        public ProjetoController(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_projetoRepository.Listar());
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível listar os projetos");
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Projeto projeto = _projetoRepository.BuscarPorId(id);

                if (projeto == null)
                {
                    return NotFound();
                }
                return Ok(projeto);
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível encontrar o projeto");
            }
        }
        [HttpPost]
        public IActionResult Cadastrar(Projeto projeto)
        {
            try
            {
                _projetoRepository.Cadastrar(projeto);

                return StatusCode(201);
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível cadastrar os projetos");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Projeto projeto)
        {
            try
            {
                _projetoRepository.Atualizar(id, projeto);

                return StatusCode(204);
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível atualizar o projeto");
            }
        }

        [Authorize(Roles = "0")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                Projeto projetoBuscado = _projetoRepository.BuscarPorId(id);

                if (projetoBuscado == null)
                {
                    return NotFound();
                }
                _projetoRepository.Deletar(id);

                return StatusCode(202);
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível deletar o projeto");
            }
        }
    }
}
