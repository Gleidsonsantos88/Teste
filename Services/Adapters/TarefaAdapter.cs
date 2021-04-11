using Model;
using Service.Request;
using System;

namespace Service.Adapters
{
    public class TarefaAdapter : ITarefaAdapter
    {
        public Tarefa ConverteAlterarTarefaRequestParaTarefa(AlterarTarefaRequest alterarTarefaRequest)
        {
            return new Tarefa
            {
                Descricao = alterarTarefaRequest.Descricao,
                UsuarioId = alterarTarefaRequest.UsuarioId,
                Situacao = (SituacaoEnum) alterarTarefaRequest.Situacao
            };
        }

        public Tarefa ConverteCriarTarefaRequestParaTarefa(CriarTarefaRequest criarTarefaRequest)
        {
            return new Tarefa
            {
                Descricao = criarTarefaRequest.Descricao,
                UsuarioId = criarTarefaRequest.UsuarioId,
                DataCriacao = DateTime.Now,
                Situacao = SituacaoEnum.Afazer
            };
        }
    }
}
