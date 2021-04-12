using Service.Enum;
using System;

namespace Service.Response
{
    public class TarefaResponse
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public SituacaoEnum Situacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioId { get; set; }
    }
}
