using Microsoft.AspNetCore.Mvc;
using Service.Request;

namespace ProdapWeb.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Cadastar()
        {
            return PartialView("_CadastrarUsuario");
        }

        public ActionResult Cadastrar(CriarUsuarioRequest usuario)
        {
            return View();
        }

        public PartialViewResult Entrar()
        {
            return PartialView("_EntrarUsuario");
        }
       
    }
}
