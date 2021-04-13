using Microsoft.AspNetCore.Mvc;
using Service.Adapters;
using Service.Enum;
using Service.Request;
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
        
        [HttpGet]
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

        [HttpPost]
        public ActionResult SalvarEdicaoTarefa(AlterarTarefaRequest alterarTarefaRequest)
        {
            try
            {
                if (_usuarioService.BuscarUsuarioSessao() == null)
                    return RedirectToAction("Index", "Usuario");

                _tarefaService.Alterar(alterarTarefaRequest);
                TempData["MensagemSucesso"] = "Tarefa alterada com sucesso";
                return RedirectToAction("Index", "Tarefa");

            }
            catch (Exception)
            {
                TempData["MensagemErro"] = "Erro ao tentar editar tarefa";
                return RedirectToAction("Index", "Tarefa");
            }
        }

        [HttpPost]
        public ActionResult CancelaEdicaoTarefa(AlterarTarefaRequest alterarTarefaRequest)
        {
            try
            {
                if (_usuarioService.BuscarUsuarioSessao() == null)
                    return RedirectToAction("Index", "Usuario");

                _tarefaService.Alterar(alterarTarefaRequest);
                TempData["MensagemSucesso"] = "Cancelamento de ediçao de tarefa foi executada com sucesso.";
                return RedirectToAction("Index", "Tarefa");

            }
            catch (Exception)
            {
                TempData["MensagemErro"] = "Erro ao tentar cancelar ediçao de tarefa";
                return RedirectToAction("Index", "Tarefa");
            }
        }

        [HttpPost]
        public ActionResult ConcluirTarefaAFazer(AlterarTarefaRequest alterarTarefaRequest)
        {
            try
            {
                if (_usuarioService.BuscarUsuarioSessao() == null)
                    return RedirectToAction("Index", "Usuario");

                _tarefaService.Alterar(alterarTarefaRequest);
                TempData["MensagemSucesso"] = "Tarefa á fazer movida para feitas com sucesso.";
                return RedirectToAction("Index", "Tarefa");

            }
            catch (Exception)
            {
                TempData["MensagemErro"] = "Erro ao tentar mover tarefa de á fazer para feitas";
                return RedirectToAction("Index", "Tarefa");
            }
        }

        [HttpDelete]
        public ActionResult RemoverTarefa(int id)
        {
            try
            {
                if (_usuarioService.BuscarUsuarioSessao() == null)
                    return RedirectToAction("Index", "Usuario");

                _tarefaService.Excluir(id);
                TempData["MensagemSucesso"] = "Tarefa excluida com sucesso.";
                return RedirectToAction("Index", "Tarefa");

            }
            catch (Exception)
            {
                TempData["MensagemErro"] = "Erro ao tentar excluir tarefa";
                return RedirectToAction("Index", "Tarefa");
            }
        }

        [HttpPost]
        public ActionResult CriarTarefa(CriarTarefaRequest criarTarefaRequest)
        {
            try
            {
                var usuario =  _usuarioService.BuscarUsuarioSessao();
                if (usuario == null)
                    return RedirectToAction("Index", "Usuario");

                criarTarefaRequest.UsuarioId = usuario.Id;
                _tarefaService.Criar(criarTarefaRequest);
                TempData["MensagemSucesso"] = "Tarefa criada com sucesso";
                return RedirectToAction("Index", "Tarefa");

            }
            catch (Exception)
            {
                TempData["MensagemErro"] = "Erro ao tentar criar tarefa";
                return RedirectToAction("Index", "Tarefa");
            }
        }
    }
}
