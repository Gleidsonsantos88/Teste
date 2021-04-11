using FluentValidation;
using Model;
using Repository;
using Service.Adapters;
using Service.Request;

namespace Service.UsuarioService
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioAdapter _usuarioAdapter;
        private readonly IValidator<CriarUsuarioRequest> _criarUsuarioRequestValidator;
        public UsuarioService(IUsuarioRepository usuarioRepository,
            IUsuarioAdapter usuarioAdapter,
            IValidator<CriarUsuarioRequest> criarUsuarioRequestValidator)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioAdapter = usuarioAdapter;
            _criarUsuarioRequestValidator = criarUsuarioRequestValidator;
        }

        public Usuario BuscarUsuarioPorNomeSenha(string nome, string senha)
        {
            return _usuarioRepository.BuscarUsuarioPorNomeSenha(nome, senha);
        }

        public bool Criar(CriarUsuarioRequest usuario)
        {
            try
            {
                _criarUsuarioRequestValidator.ValidateAndThrow(usuario);
                _usuarioRepository.Criar(_usuarioAdapter.ConverteCriarUsuarioRequestParaUsuario(usuario));
                return true;
            }
            catch (ValidationException exv)
            {
                throw new ValidationException(exv.Errors);
            }
        }
    }
}
