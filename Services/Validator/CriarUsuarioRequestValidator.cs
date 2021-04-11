using FluentValidation;
using Service.Request;

namespace Service.Validator
{
    public class CriarUsuarioRequestValidator : AbstractValidator<CriarUsuarioRequest>
	{
		public CriarUsuarioRequestValidator()
		{
			RuleFor(x => x.Senha)
				.NotNull().WithMessage("Informe a senha");

			RuleFor(x => x.Nome)
				.NotNull().WithMessage("Informe o nome");
		}
	}
}
