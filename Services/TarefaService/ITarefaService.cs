using Model;
using Service.Request;
using System.Collections.Generic;

namespace Service.TarefaService
{
    public interface ITarefaService
    {
        bool Criar(CriarTarefaRequest tarefa);
        Tarefa BuscarPorId(int id);
        IEnumerable<Tarefa> BuscarPorUsuarioId(int usuarioId);
        bool Alterar(AlterarTarefaRequest obj);
        Tarefa BuscarPorTarefaIdEUsuarioId(int id, int usuarioId);
        bool Excluir(int id);
    }
}
