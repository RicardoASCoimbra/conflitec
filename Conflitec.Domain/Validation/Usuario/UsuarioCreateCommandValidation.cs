using Conflitec.Domain.Commads.Usuario;
using FluentValidation;

namespace Conflitec.Domain.Validation.Usuario
{
    public class UsuarioCreateCommandValidation : CommandValidation<UsuarioCreateCommand>
    {
        public UsuarioCreateCommandValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O Nome do usuário é obrigatório!");
            RuleFor(x => x.Nome)
                .MaximumLength(255).WithMessage("O campo Nome não pode conter mais que 255 caracteres!");
            RuleFor(x => x.DataNascimento)
                .NotEmpty().WithMessage("A Data de Nascimento do usuário é obrigatório!");
            RuleFor(x => x.Escolaridade)
                .NotEmpty().WithMessage("A Escolaridade do usuário é obrigatório!");
        }
    }
}