using System;

namespace Model
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Descricao  { get; set; }
        public SituacaoEnum Situacao { get; set; }
        public DateTime DataCriacao { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
