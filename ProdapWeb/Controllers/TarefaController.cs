using Microsoft.AspNetCore.Mvc;
using Service.Adapters;
using Service.Request;
using Service.TarefaService;
using Service.UsuarioService;
using System;

namespace ProdapWeb.Controllers
{
    public class TarefaController : Controller
    {
        private readonly ITarefaService _tarefaService;
        private readonly IUsuarioService _usuarioService;

        public TarefaController(ITarefaService tarefaService,
            IUsuarioService usuarioService)
        {
            _tarefaService = tarefaService;
            _usuarioService = usuarioService;
        }
        
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
