using FluentValidation;
using Microsoft.AspNetCore.Http;
using Model;
using Newtonsoft.Json;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsuarioService(IUsuarioRepository usuarioRepository,
            IUsuarioAdapter usuarioAdapter,
            IValidator<CriarUsuarioRequest> criarUsuarioRequestValidator,
            IHttpContextAccessor httpContextAccessor)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioAdapter = usuarioAdapter;
            _criarUsuarioRequestValidator = criarUsuarioRequestValidator;
            _httpContextAccessor = httpContextAccessor;
        }

        public Usuario BuscarUsuarioPorNomeSenha(string nome, string senha)
        {
            return _usuarioRepository.BuscarUsuarioPorNomeSenha(nome, senha);
        }

        public Usuario BuscarUsuarioSessao()
        {
            var sessao = _httpContextAccessor.HttpContext.Session.GetString("Usuario");
          
            if (!string.IsNullOrEmpty(sessao))
                return  JsonConvert.DeserializeObject<Usuario>(_httpContextAccessor.HttpContext.Session.GetString("Usuario"));
            
            return null;
        }

        public void ColocaUsuarioSessao(Usuario usuario)
        {
            var sessao = _httpContextAccessor.HttpContext.Session.GetString("Usuario");
            
            if (string.IsNullOrEmpty(sessao))
                _httpContextAccessor.HttpContext.Session.SetString("Usuario", JsonConvert.SerializeObject(usuario));
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
