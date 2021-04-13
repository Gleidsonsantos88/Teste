using Model;
using Service.Request;
using Service.Response;
using System;
using System.Collections.Generic;

namespace Service.Adapters
{
    public class TarefaAdapter : ITarefaAdapter
    {
        public Tarefa ConverteAlterarTarefaRequestParaTarefa(AlterarTarefaRequest alterarTarefaRequest)
        {
            return new Tarefa
            {
                Id = alterarTarefaRequest.Id,
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

        public List<TarefaResponse> ConverteTarefaParaTarefaResponse(List<Tarefa> tarefas)
        {
            var tarefaResponse = new List<TarefaResponse>();

            foreach (var tarefa in tarefas)
            {
                tarefaResponse.Add(new TarefaResponse() { 
                  DataCriacao = tarefa.DataCriacao,
                  Descricao = tarefa.Descricao,
                  Id = tarefa.Id,
                  Situacao = (Enum.SituacaoEnum) tarefa.Situacao,
                  UsuarioId = tarefa.UsuarioId
                });
            }
            return tarefaResponse;
        }
    }
}
