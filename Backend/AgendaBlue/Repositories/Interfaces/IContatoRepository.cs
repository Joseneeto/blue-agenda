using AgendaBlue.Models;

namespace AgendaBlue.Repositories.Interfaces
{
    public interface IContatoRepository
    {
        Task<List<ContatoModel>> BuscarTodosContatos();
        Task<ContatoModel> BuscarPorId(int id);
        Task<ContatoModel> Adicionar(ContatoModel contato);
        Task<ContatoModel> Atualizar(ContatoModel contato, int id);
        Task<bool> Apagar(int id);
    }
}
