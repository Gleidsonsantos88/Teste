using Model;
using System.Collections.Generic;
using System.Linq;

namespace Repository.EfCore
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly ProdapDbContext _prodapDbContext;
        public TarefaRepository(ProdapDbContext prodapDbContext)
        {
            _prodapDbContext = prodapDbContext;
        }

        public void Alterar(Tarefa obj)
        {
            var tarefa = BuscarPorId(obj.Id);
            if(tarefa != null)
            {
                tarefa.Descricao = obj.Descricao;
                tarefa.Situacao = obj.Situacao;
            }
            _prodapDbContext.SaveChanges();
        }

        public Tarefa BuscarPorId(int id)
        {
            return _prodapDbContext.Tarefas.Where(x => x.Id == id)?.FirstOrDefault();
        }

        public Tarefa BuscarPorTarefaIdEUsuarioId(int id, int usuarioId)
        {
            return _prodapDbContext.Tarefas.Where(x => x.UsuarioId == usuarioId && x.UsuarioId == usuarioId)?.FirstOrDefault();
        }

        public IEnumerable<Tarefa> BuscarPorUsuarioId(int usuarioId)
        {
            return _prodapDbContext.Tarefas.Where(x => x.UsuarioId == usuarioId).ToList();
        }

        public IEnumerable<Tarefa> BuscarTodos()
        {
            return _prodapDbContext.Tarefas.ToList();
        }

        public void Criar(Tarefa obj)
        {
            _prodapDbContext.Tarefas.Add(obj);
            _prodapDbContext.SaveChanges();
        }

        public void Excluir(Tarefa obj)
        {
            var tarefa = BuscarPorId(obj.Id);
            _prodapDbContext.Tarefas.Remove(tarefa);
            _prodapDbContext.SaveChanges();
        }
    }
}
