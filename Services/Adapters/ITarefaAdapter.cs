using Service.Request;

namespace Service.Adapters
{
    public interface ITarefaAdapter
    {
        Model.Tarefa ConverteCriarTarefaRequestParaTarefa(CriarTarefaRequest criarTarefaRequest);
        Model.Tarefa ConverteAlterarTarefaRequestParaTarefa(AlterarTarefaRequest AlterarTarefaRequest);
        
    }
}
