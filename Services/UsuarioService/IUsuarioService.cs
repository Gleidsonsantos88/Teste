using Model;
using Service.Request;

namespace Service.UsuarioService
{
    public interface IUsuarioService
    {
        bool Criar(CriarUsuarioRequest usuario);
        Usuario BuscarUsuarioPorNomeSenha(string nome, string senha);

        public void ColocaUsuarioSessao(Usuario usuario);

        public Usuario BuscarUsuarioSessao();
    }
}
