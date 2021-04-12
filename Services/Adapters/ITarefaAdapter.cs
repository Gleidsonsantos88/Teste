using Service.Request;
using Service.Response;
using System.Collections.Generic;

namespace Service.Adapters
{
    public interface ITarefaAdapter
    {
        Model.Tarefa ConverteCriarTarefaRequestParaTarefa(CriarTarefaRequest criarTarefaRequest);
        Model.Tarefa ConverteAlterarTarefaRequestParaTarefa(AlterarTarefaRequest AlterarTarefaRequest);
        List<TarefaResponse> ConverteTarefaParaTarefaResponse(List<Model.Tarefa> tarefas);
    }
}
