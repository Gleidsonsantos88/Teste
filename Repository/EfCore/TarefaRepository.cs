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

        public bool Alterar(Tarefa obj)
        {
            var tarefa = BuscarPorTarefaIdEUsuarioId(obj.Id, obj.UsuarioId);
            if (tarefa == null)
                return false;

            tarefa.Descricao = !string.IsNullOrEmpty(obj.Descricao) ? obj.Descricao : tarefa.Descricao;
            tarefa.Situacao  = obj.Situacao;

            _prodapDbContext.Update(tarefa);
            _prodapDbContext.SaveChanges();
            return true;
        }

        public Tarefa BuscarPorId(int id)
        {
            return _prodapDbContext.Tarefas.Where(x => x.Id == id)?
                                           .Select(s =>
                                            new Tarefa
                                            {
                                                Descricao = s.Descricao,
                                                Id = s.Id,
                                                Situacao = s.Situacao,
                                                UsuarioId = s.UsuarioId,
                                                DataCriacao = s.DataCriacao
                                            }
                                            ).FirstOrDefault();
        }

        public Tarefa BuscarPorTarefaIdEUsuarioId(int id, int usuarioId)
        {
            return _prodapDbContext.Tarefas.Where(x => x.Id == id &&
                                                  x.UsuarioId == usuarioId)?.Select(s =>
                                                                            new Tarefa
                                                                            {
                                                                                Descricao = s.Descricao,
                                                                                Id = s.Id,
                                                                                Situacao = s.Situacao,
                                                                                UsuarioId = s.UsuarioId,
                                                                                DataCriacao = s.DataCriacao
                                                                            }
                                                                            ).FirstOrDefault();
        }

        public IEnumerable<Tarefa> BuscarPorUsuarioId(int usuarioId)
        {
            return _prodapDbContext.Tarefas.Where(x => x.UsuarioId == usuarioId)?.Select(s =>
                                                                            new Tarefa
                                                                            {
                                                                                Descricao = s.Descricao,
                                                                                Id = s.Id,
                                                                                Situacao = s.Situacao,
                                                                                UsuarioId = s.UsuarioId,
                                                                                DataCriacao = s.DataCriacao
                                                                            }
                                                                            ).ToList().OrderBy(x => x.DataCriacao);
        }

        public IEnumerable<Tarefa> BuscarTodos()
        {
            return _prodapDbContext.Tarefas?.Select(s =>
                                            new Tarefa
                                            {
                                                Descricao = s.Descricao,
                                                Id = s.Id,
                                                Situacao = s.Situacao,
                                                UsuarioId = s.UsuarioId,
                                                DataCriacao = s.DataCriacao
                                            }
                                            ).ToList().OrderBy(x => x.DataCriacao);
        }

        public bool Criar(Tarefa obj)
        {
           
            _prodapDbContext.Tarefas.Add(obj);
            _prodapDbContext.SaveChanges();
            return true;
           
        }

        public bool Excluir(int id)
        {
            var tarefa = BuscarPorId(id);
            if (tarefa != null)
            {
                _prodapDbContext.Tarefas.Remove(tarefa);
                _prodapDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
