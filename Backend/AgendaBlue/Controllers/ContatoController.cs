using AgendaBlue.Models;
using AgendaBlue.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaBlue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContatoModel>>> BuscarTodosContatos()
        {
            List<ContatoModel> contatos = await _contatoRepository.BuscarTodosContatos();
            return Ok(contatos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ContatoModel>>> BuscarPorId(int id)
        {
            ContatoModel contato = await _contatoRepository.BuscarPorId(id);
            return Ok(contato);
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult<ContatoModel>> Cadastrar([FromBody] ContatoModel contatoModel)
        {
            ContatoModel contato = await _contatoRepository.Adicionar(contatoModel);

            return Ok(contato); 
        }

        [HttpPut("alterar/{id}")]
        public async Task<ActionResult<ContatoModel>> Atualizar([FromBody] ContatoModel contatoModel, int id)
        {
            contatoModel.id= id;
            ContatoModel contato = await _contatoRepository.Atualizar(contatoModel, id);

            return Ok(contato);
        }

        [HttpDelete("remover/{id}")]
        public async Task<ActionResult<ContatoModel>> Apagar(int id)
        {
            bool apagado = await _contatoRepository.Apagar(id);

            return Ok(apagado);
        }

    }
}
