using FluentValidation;
using Service.Request;

namespace Service.Validator
{
    public class CriarTarefaRequestValidator : AbstractValidator<CriarTarefaRequest>
	{
		public CriarTarefaRequestValidator()
		{
			RuleFor(x => x.Descricao)
				.NotNull().WithMessage("Informe a Descrição da tarefa");

			RuleFor(x => x.UsuarioId)
				.GreaterThan(0).WithMessage("Informe o código do usuário");
		}
    }
}
