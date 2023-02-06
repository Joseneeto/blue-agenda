using AgendaBlue.Data;
using AgendaBlue.Models;
using AgendaBlue.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendaBlue.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly AgendaDBContex _dbContex;
        public ContatoRepository(AgendaDBContex agendaDBContex )
        {
            _dbContex =  agendaDBContex;
        }

        public async Task<ContatoModel> BuscarPorId(int id)
        {
            if(id == null)
            {
                return null;
            }
            else
            {
                return await _dbContex.Contato.FirstOrDefaultAsync(x => x.id == id);
            }
        }

        public async Task<List<ContatoModel>> BuscarTodosContatos()
        {
            return await _dbContex.Contato.ToListAsync();
        }
        public async Task<ContatoModel> Adicionar(ContatoModel contato)
        {
            await _dbContex.Contato.AddAsync(contato);
            await _dbContex.SaveChangesAsync();

            return contato;
        }

        public async Task<ContatoModel> Atualizar(ContatoModel contato, int id)
        {
            ContatoModel contatoPorId = await BuscarPorId(id);
            if(contatoPorId == null)
            {
                throw new Exception($"Usuário para o ID:{id} não foi encontrado no banco de dados.");
            }

            contatoPorId.name = contato.name;
            contatoPorId.email = contato.email;
            contatoPorId.phone = contato.phone;

            _dbContex.Contato.Update(contatoPorId);
            await _dbContex.SaveChangesAsync();

            return contatoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            ContatoModel contatoPorId = await BuscarPorId(id);
            if (contatoPorId == null)
            {
                throw new Exception($"Usuário para o ID:{id} não foi encontrado no banco de dados.");
            }

            _dbContex.Contato.Remove(contatoPorId);
            await _dbContex.SaveChangesAsync();

            return true;
        }

    }
}
