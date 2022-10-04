using Conflitec.Domain.Core.Commands;
using Conflitec.Domain.Enuns;
using Conflitec.Domain.Validation.Usuario;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conflitec.Domain.Commads.Usuario
{
    public class UsuarioEditCommand : Command
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Escolaridade { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new UsuarioEditCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
