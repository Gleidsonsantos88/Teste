using Model;
using Service.Request;

namespace Service.Adapters
{
    public class UsuarioAdapter : IUsuarioAdapter
    {
      
        public Usuario ConverteCriarUsuarioRequestParaUsuario(CriarUsuarioRequest criarUsuarioRequest)
        {
            return new Usuario
            {
                Nome = criarUsuarioRequest.Nome,
                Senha = criarUsuarioRequest.Senha
            };
        }
    }
}