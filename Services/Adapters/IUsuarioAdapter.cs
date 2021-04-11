using Service.Request;

namespace Service.Adapters
{
    public interface IUsuarioAdapter
    {
        Model.Usuario ConverteCriarUsuarioRequestParaUsuario(CriarUsuarioRequest criarUsuarioRequest);
    }
}
