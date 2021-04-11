using FluentValidation;
using Service.Enum;
using Service.Request;

namespace Service.Validator
{
    public class AlterarTarefaRequestValidator : AbstractValidator<AlterarTarefaRequest>
	{
		public AlterarTarefaRequestValidator()
		{
			RuleFor(x => x.Descricao)
				.NotNull().WithMessage("Informe a Descrição da tarefa");

			RuleFor(x => x.UsuarioId)
				.GreaterThan(0).WithMessage("Informe o código do usuário");

			RuleFor(x => x.Situacao)
				.IsInEnum().WithMessage("Informe a situação da tarefa");
		}
	}
}
