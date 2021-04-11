using Model;
using System.Collections.Generic;

namespace Repository.EfCore
{
    public interface ITarefaRepository : IQuery<Tarefa>, ICommand<Tarefa>
    {
        IEnumerable<Tarefa> BuscarPorUsuarioId(int usuarioId);
        Tarefa BuscarPorTarefaIdEUsuarioId(int id, int usuarioId);
    }
}
