using Model;

namespace Repository
{
    public interface IUsuarioRepository
    {
        bool Criar(Usuario usuario);
        Usuario BuscarUsuarioPorNomeSenha(string nome, string senha);
    }
}
