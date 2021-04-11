using FluentValidation;
using Model;
using Moq;
using Repository.EfCore;
using Service.Adapters;
using Service.Request;
using Service.TarefaService;
using Service.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ProdapTest
{
    public class TarefaServiceTest
    {
        private readonly Mock<ITarefaRepository> _tarefaRepositoryMock;
        private readonly TarefaService _tarefaService;
        private readonly CriarTarefaRequestValidator  _criarTarefaRequestValidator;
        private readonly AlterarTarefaRequestValidator _alterarTarefaRequestValidator;
        private readonly TarefaAdapter _tarefaAdapter;
        public TarefaServiceTest()
        {
            _tarefaRepositoryMock = new Mock<ITarefaRepository>();
            _criarTarefaRequestValidator = new CriarTarefaRequestValidator();
            _alterarTarefaRequestValidator = new AlterarTarefaRequestValidator();
            _tarefaAdapter = new TarefaAdapter();
            _tarefaService = new TarefaService(_tarefaRepositoryMock.Object, _criarTarefaRequestValidator, _tarefaAdapter, _alterarTarefaRequestValidator);
        }

        [Fact]
        public void Criar_Tarefa_Sucesso()
        {

            var criarTarefaRequest = new CriarTarefaRequest()
            {
                Descricao = "Criação de tarefa com sucesso.",
                UsuarioId = 1
            };

            var tarefa = _tarefaAdapter.ConverteCriarTarefaRequestParaTarefa(criarTarefaRequest);

            _tarefaRepositoryMock.Setup(repository => repository.Criar(tarefa)).Verifiable();
            var response = _tarefaService.Criar(criarTarefaRequest);

            Assert.True(response);
        }

        [Fact]
        public void Criar_Tarefa_Sem_Descricao_E_UsuarioId()
        {
            //Arrange
            var criarTarefaRequest = new CriarTarefaRequest();
            var mensagemDescricao = "Informe a Descrição da tarefa";
            var mensagemCodigoUsuario = "Informe o código do usuário";

            //Act
            Action act = () => _tarefaService.Criar(criarTarefaRequest);
            ValidationException exception = Assert.Throws<ValidationException>(act);

            //Assert
            Assert.True(exception.Errors.ToArray()[0].ErrorMessage  == mensagemDescricao);
            Assert.True(exception.Errors.ToArray()[1].ErrorMessage == mensagemCodigoUsuario);
        }

        [Fact]
        public void Criar_Tarefa_Sem_Descricao()
        {
            //Arrange
            var criarTarefaRequest = new CriarTarefaRequest();
            var mensagemDescricao = "Informe a Descrição da tarefa";

            //Act
            Action act = () => _tarefaService.Criar(criarTarefaRequest);
            ValidationException exception = Assert.Throws<ValidationException>(act);

            //Assert
            Assert.True(exception.Errors.ToArray()[0].ErrorMessage == mensagemDescricao);
        }

        [Fact]
        public void Criar_Tarefa_Sem_UsuarioId()
        {
            //Arrange
            var criarTarefaRequest = new CriarTarefaRequest();
            var mensagemDescricao = "Informe a Descrição da tarefa";

            //Act
            Action act = () => _tarefaService.Criar(criarTarefaRequest);
            ValidationException exception = Assert.Throws<ValidationException>(act);

            //Assert
            Assert.True(exception.Errors.ToArray()[0].ErrorMessage == mensagemDescricao);
        }

        [Fact]
        public void Buscar_Tarefa_Por_Id()
        {
            //Arrange
            var tarefa = new Tarefa
            {
                DataCriacao = DateTime.Now,
                Descricao = "Tarefa por id",
                Id = 1,
                Situacao = SituacaoEnum.Afazer,
                UsuarioId = 1
            };

            _tarefaRepositoryMock.Setup(repository => repository.BuscarPorId(It.IsAny<int>()))
                .Returns(tarefa);

            //Act
            var response = _tarefaService.BuscarPorId(1);

            //Assert
            Assert.Equal(response, tarefa);
        }


        [Fact]
        public void Buscar_Tarefa_Por_Id_Tarefa_Nao_Encontrada()
        { 
            //Arrange
            Tarefa tarefa = null;

            _tarefaRepositoryMock.Setup(repository => repository.BuscarPorId(It.IsAny<int>()))
                .Returns(tarefa);

            //Act
            var response = _tarefaService.BuscarPorId(1);
          
            //Assert
            Assert.Equal(response, tarefa);
        }


        [Fact]
        public void Buscar_Por_Usuario_Id()
        {
            //Arrange
            List<Tarefa> tarefas = new List<Tarefa>() {

                new Tarefa
                {
                     DataCriacao = DateTime.Now,
                     Descricao = "Tarefa 01",
                     Id = 1,
                     Situacao = SituacaoEnum.Afazer,
                     UsuarioId = 1
                },
                new Tarefa
                {
                     DataCriacao = DateTime.Now,
                     Descricao = "Tarefa 02",
                     Id = 1,
                     Situacao = SituacaoEnum.Afazer,
                     UsuarioId = 1
                }              
            };

            _tarefaRepositoryMock.Setup(repository => repository.BuscarPorUsuarioId(1))
                .Returns(tarefas);

            //Act
            var response = _tarefaService.BuscarPorUsuarioId(1);

            //Assert
            Assert.True(response.ToList().Count == 2);
        }


        [Fact]
        public void Alterar_Tarefa_Sucesso()
        {

            var alterarTarefaRequest = new AlterarTarefaRequest()
            {
                Descricao = "Alteração de tarefa com sucesso.",
                UsuarioId = 1,
                Situacao = Service.Enum.SituacaoEnum.Feitos
            };

            var tarefa = _tarefaAdapter.ConverteAlterarTarefaRequestParaTarefa(alterarTarefaRequest);

            _tarefaRepositoryMock.Setup(repository => repository.Criar(tarefa)).Verifiable();
            var response = _tarefaService.Alterar(alterarTarefaRequest);

            Assert.True(response);
        }


        [Fact]
        public void Alterar_Tarefa_Sem_Descricao_E_UsuarioId_Situacao()
        {
            //Arrange
            var alterarTarefaRequest = new AlterarTarefaRequest();
            var mensagemDescricao = "Informe a Descrição da tarefa";
            var mensagemCodigoUsuario = "Informe o código do usuário";
            var mensagemSituacao = "Informe a situação da tarefa";

            //Act
            Action act = () => _tarefaService.Alterar(alterarTarefaRequest);
            ValidationException exception = Assert.Throws<ValidationException>(act);

            //Assert
            Assert.True(exception.Errors.ToArray()[0].ErrorMessage == mensagemDescricao);
            Assert.True(exception.Errors.ToArray()[1].ErrorMessage == mensagemCodigoUsuario);
            Assert.True(exception.Errors.ToArray()[2].ErrorMessage == mensagemSituacao);
        }

    }
}
