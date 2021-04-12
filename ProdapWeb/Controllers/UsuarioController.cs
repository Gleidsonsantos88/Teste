using Microsoft.AspNetCore.Mvc;
using Service.Adapters;
using Service.Request;
using Service.UsuarioService;

namespace ProdapWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioAdapter _usuarioAdapter;
        public UsuarioController(IUsuarioService usuarioService,
            IUsuarioAdapter usuarioAdapter)
        {
            _usuarioService = usuarioService;
            _usuarioAdapter = usuarioAdapter;
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (_usuarioService.BuscarUsuarioSessao() != null)
                return RedirectToAction("Index", "Tarefa");

            return View();
        }

        [HttpGet]
        public PartialViewResult Cadastar()
        {
            return PartialView("_CadastrarUsuario");
        }

        [HttpPost]
        public ActionResult Cadastrar(CriarUsuarioRequest usuario)
        {
            try
            {
                var usuarioExistente = _usuarioService.BuscarUsuarioPorNomeSenha(usuario.Nome, usuario.Senha);
                if (usuarioExistente == null)
                {
                    _usuarioService.Criar(usuario);
                    usuarioExistente = _usuarioService.BuscarUsuarioPorNomeSenha(usuario.Nome, usuario.Senha);
                    usuario.Id = usuarioExistente.Id;

                    _usuarioService.ColocaUsuarioSessao(_usuarioAdapter.ConverteCriarUsuarioRequestParaUsuario(usuario));

                    return RedirectToAction("Index", "Tarefa");
                }

                TempData["Mensagem"] = "O usuário já esta cadastrado, click no botão (Entrar com usuário existente) ";
                return RedirectToAction("Index", "Usuario");
            }
            catch (System.Exception ex)
            {
                TempData["Mensagem"] = "Erro ao tentar cadastrar usuário";
                return RedirectToAction("Index", "Usuario");
            }
        }

        [HttpGet]
        public PartialViewResult Entrar()
        {
            return PartialView("_EntrarUsuario");
        }

        [HttpPost]
        public ActionResult Entrar(CriarUsuarioRequest usuario)
        {
            try
            {
                var usuarioExistente = _usuarioService.BuscarUsuarioPorNomeSenha(usuario.Nome, usuario.Senha);
                if (usuarioExistente == null)
                {
                    TempData["Mensagem"] = "Usuário não cadastrado";
                    return RedirectToAction("Index", "Usuario");
                }
                usuario.Id = usuarioExistente.Id;
                _usuarioService.ColocaUsuarioSessao(_usuarioAdapter.ConverteCriarUsuarioRequestParaUsuario(usuario));

                return RedirectToAction("Index", "Tarefa");
            }
            catch (System.Exception)
            {
                TempData["Mensagem"] = "Erro ao tentar entrar no sistema";
                return RedirectToAction("Index", "Usuario");
            }
        }
    }
}
