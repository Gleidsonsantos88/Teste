using Microsoft.AspNetCore.Mvc;
using Service.Adapters;
using Service.Enum;
using Service.TarefaService;
using Service.UsuarioService;
using System;
using System.Linq;

namespace ProdapWeb.Controllers
{
    public class TarefaController : Controller
    {
        private readonly ITarefaService _tarefaService;
        private readonly IUsuarioService _usuarioService;
        private readonly ITarefaAdapter _tarefaAdapter;

        public TarefaController(ITarefaService tarefaService,
            IUsuarioService usuarioService,
            ITarefaAdapter tarefaAdapter)
        {
            _tarefaService = tarefaService;
            _usuarioService = usuarioService;
            _tarefaAdapter = tarefaAdapter;
        }
        
        public ActionResult Index()
        {
            try
            {
                if(_usuarioService.BuscarUsuarioSessao() == null)
                    return RedirectToAction("Index", "Usuario");
              
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult PartialViewTarefa()
        {
            var usuario = _usuarioService.BuscarUsuarioSessao();
            if (usuario == null)
                return RedirectToAction("Index", "Usuario");

            var tarefas = _tarefaAdapter.ConverteTarefaParaTarefaResponse(
                                         _tarefaService.BuscarPorUsuarioId(usuario.Id)?.ToList());

            if(tarefas.Any(x=>x.Situacao == SituacaoEnum.Editando))
                return PartialView("_EditarTarefa", tarefas);
            else
                return PartialView("_NovaTarefa", tarefas);
        }

    }
}
