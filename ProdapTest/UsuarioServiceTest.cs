using FluentValidation;
using Model;
using Moq;
using Repository;
using Service.Adapters;
using Service.Request;
using Service.UsuarioService;
using Service.Validator;
using System;
using System.Linq;
using Xunit;

namespace ProdapTest
{
    public class UsuarioServiceTest
    {

        private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;
        private readonly UsuarioService _usuarioService;
        private readonly CriarUsuarioRequestValidator _criarUsuarioRequestValidator;
        private readonly UsuarioAdapter _usuarioAdapter;

        public UsuarioServiceTest()
        {
            _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            _criarUsuarioRequestValidator = new CriarUsuarioRequestValidator();
            _usuarioAdapter = new UsuarioAdapter();
            _usuarioService = new UsuarioService(
                _usuarioRepositoryMock.Object,
                _usuarioAdapter,
                _criarUsuarioRequestValidator
             );
        }

        [Fact]
        public void Criar_Usuario_Sucesso()
        {
            //Arrange
            var criarUsuarioRequest = new CriarUsuarioRequest()
            {
                Nome = "Gleidson",
                Senha = "1234"
            };

            var usuario = _usuarioAdapter.ConverteCriarUsuarioRequestParaUsuario(criarUsuarioRequest);

            _usuarioRepositoryMock.Setup(repository => repository.Criar(usuario)).Returns(true);

            //Act
            var response = _usuarioService.Criar(criarUsuarioRequest);

            //Assert
            Assert.True(response);
        }

        [Fact]
        public void Criar_Usuario_Sem_Nome_E_Senha_Erro()
        {
            //Arrange
            var criarUsuarioRequest = new CriarUsuarioRequest();
            var mensagemSenha = "Informe a senha";
            var mensagemNome = "Informe o nome";

            //Act
            Action act = () => _usuarioService.Criar(criarUsuarioRequest);
            ValidationException exception = Assert.Throws<ValidationException>(act);

            //Assert
            Assert.True(exception.Errors.ToArray()[0].ErrorMessage == mensagemSenha);
            Assert.True(exception.Errors.ToArray()[1].ErrorMessage == mensagemNome);
        }


        [Fact]
        public void Criar_Usuario_Sem_Senha_Erro()
        {
            //Arrange
            var criarUsuarioRequest = new CriarUsuarioRequest() { Nome = "Gleidson" };
            var mensagemSenha = "Informe a senha";

            //Act
            Action act = () => _usuarioService.Criar(criarUsuarioRequest);
            ValidationException exception = Assert.Throws<ValidationException>(act);

            //Assert
            Assert.True(exception.Errors.ToArray()[0].ErrorMessage == mensagemSenha);
        }

        [Fact]
        public void Criar_Usuario_Sem_Nome_Erro()
        {
            //Arrange
            var criarUsuarioRequest = new CriarUsuarioRequest() { Senha = "1234" };
            var mensagemSenha = "Informe o nome";

            //Act
            Action act = () => _usuarioService.Criar(criarUsuarioRequest);
            ValidationException exception = Assert.Throws<ValidationException>(act);

            //Assert
            Assert.True(exception.Errors.ToArray()[0].ErrorMessage == mensagemSenha);
        }

        [Fact]
        public void Buscar_Usuario_Nome_Senha()
        {
            //Arrange
            var usuario = new Usuario
            {
                Id = 1,
                Nome = "Gleidson"                
            };

            _usuarioRepositoryMock.Setup(repository => repository.BuscarUsuarioPorNomeSenha(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(usuario);

            //Act
            var response = _usuarioService.BuscarUsuarioPorNomeSenha(It.IsAny<string>(), It.IsAny<string>());

            //Assert
            Assert.Equal(response, usuario);
        }


        [Fact]
        public void Buscar_Usuario_Nome_Senha_Nao_Encontrado()
        {
            //Arrange
            Usuario usuario = null;

            _usuarioRepositoryMock.Setup(repository => repository.BuscarUsuarioPorNomeSenha(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(usuario);

            //Act
            var response = _usuarioService.BuscarUsuarioPorNomeSenha(It.IsAny<string>(), It.IsAny<string>());

            //Assert
            Assert.Equal(response, usuario);
        }

    }
}
