using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Senha { get; set; }

        public List<Tarefa> Tarefas { get; set; }
    }
}
