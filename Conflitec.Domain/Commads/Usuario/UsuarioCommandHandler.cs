using Conflitec.Domain.Core.Interfaces;
using Conflitec.Domain.Core.Notifications;
using Conflitec.Domain.Interfaces.Infra.Data.Repositories;
using Conflitec.Domain.Interfaces.Infra.Data;
using MediatR;
using Conflitec.Domain.Models;

namespace Conflitec.Domain.Commads.Usuario
{
    public class UsuarioCommandHandler : CommandHandler, IRequestHandler<UsuarioCreateCommand>, IRequestHandler<UsuarioEditCommand>
    {
        private readonly IMediatorHandler _bus;
        private readonly IUsuarioRepository _repository;

        public UsuarioCommandHandler(IUsuarioRepository repository,
            IMediatorHandler bus,
            IUnitOfWork uow,
            INotificationHandler<DomainNotification> notifications)

            : base(uow, bus, notifications)
        {
            _bus = bus;
            _repository = repository;
        }

        public async Task<Unit> Handle(UsuarioCreateCommand request, CancellationToken cancellationToken)
        {

            if (!request.IsValid())
                NotifyValidationErrors(request);
            else
            {              
                Usuarios usuario = new Usuarios(Guid.NewGuid(), request.Nome, request.Sobrenome, request.Email, request.DataNascimento, request.Escolaridade);
                _repository.Add(usuario);
                await Commit();                
            }

            return Unit.Value;
        }

        public async Task<Unit> Handle(UsuarioEditCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
            }
            else
            {
                Usuarios usuarioPrincipal = await _repository.GetById(request.Id);            
                usuarioPrincipal.SetDados(request.Nome, request.Sobrenome, request.Email, request.DataNascimento, request.Escolaridade);
                _repository.Update(usuarioPrincipal);

                await Commit();
               
            }
            return Unit.Value;
        }
    }
}
