using Service.Enum;

namespace Service.Request
{
    public class AlterarTarefaRequest
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
        public SituacaoEnum Situacao { get; set; }
    }
}
