using Loja.Core.Models;
using Loja.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Loja.Api.Controllers
{
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService service;

        public CategoriaController(CategoriaService service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var categorias = service.Listar();
            return Ok(categorias);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Categoria categoria)
        {
            var sucesso = service.Criar(categoria, out var erros);
            return sucesso ? Ok(categoria) : UnprocessableEntity(erros);
        }


        [HttpGet("tela")]
        public async Task<IActionResult> Tela()
        {
            Response.Headers.ContentType = "text/html";
            await Response.WriteAsync("<h1>Hello, world!</h1>");
            return Ok();
        }
    }
}
