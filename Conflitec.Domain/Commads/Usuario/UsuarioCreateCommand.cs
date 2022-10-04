using Conflitec.Domain.Core.Commands;
using Conflitec.Domain.Enuns;
using Conflitec.Domain.Validation.Usuario;

namespace Conflitec.Domain.Commads.Usuario
{
    public class UsuarioCreateCommand : Command
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Escolaridade { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new UsuarioCreateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
