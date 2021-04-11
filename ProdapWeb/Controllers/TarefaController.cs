using Microsoft.AspNetCore.Mvc;
using Service.Adapters;
using Service.Request;
using Service.TarefaService;
using System;

namespace ProdapWeb.Controllers
{
    public class TarefaController : Controller
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }
        
        public ActionResult Index()
        {
            try
            {
                var tarefa = new CriarTarefaRequest() { Descricao = "teste", UsuarioId = 1};

                _tarefaService.Criar(tarefa);
                return View();
            
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
