using Conflitec.Domain.Core.Commands;
using FluentValidation;

namespace Conflitec.Domain.Validation
{
    public class CommandValidation<T> : AbstractValidator<T> where T : Command
    {
    }
}
