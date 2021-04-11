using Service.Enum;
using System;

namespace Service.Request
{
    public class CriarTarefaRequest
    {
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
    }
}
