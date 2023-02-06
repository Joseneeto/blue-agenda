using AgendaBlue.Controllers;
using AgendaBlue.Models;
using AgendaBlue.Repositories;
using AgendaBlue.Repositories.Interfaces;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Agenda.Tests
{
    public class AgendaTest
    {

        private readonly IContatoRepository _contatoRepository; 
        private readonly ContatoModel _contatoModel;

        [Fact]
        public async void IdValido()
        {
            ContatoModel contatoModel = new ContatoModel();
            contatoModel.id = 1;
            contatoModel.name = "Jos�";
            contatoModel.email = "ze@gmail.com";
            contatoModel.phone = "81988665544";


            //Contexto
            _contatoRepository.BuscarPorId(Arg.Any<int>()).ReturnsNull();

            //A��o
            var contato = await _contatoRepository.BuscarPorId(contatoModel.id);

            //Verifica��o
            Assert.Null(contato);
        }
    }
}