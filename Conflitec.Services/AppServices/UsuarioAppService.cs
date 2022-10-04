using AutoMapper;
using Conflitec.Domain.Commads.Usuario;
using Conflitec.Domain.Core.Interfaces;
using Conflitec.Domain.Core.Notifications;
using Conflitec.Domain.Enuns;
using Conflitec.Domain.Interfaces.Infra.Data.Repositories;
using Conflitec.Domain.Models;
using Conflitec.Domain.Utils;
using Conflitec.Services.Interfaces;
using Conflitec.Services.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Conflitec.Services.AppServices
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly IHttpContextAccessor _httpContext;
        private readonly DomainNotificationHandler _notifications;
        private readonly IUsuarioRepository _repository;

        public UsuarioAppService(IMediatorHandler bus, IMapper mapper, INotificationHandler<DomainNotification> notifications,
            IUsuarioRepository repository, IHttpContextAccessor httpContext)
        {
            _bus = bus;
            _mapper = mapper;
            _notifications = (DomainNotificationHandler)notifications;
            _repository = repository;
            _httpContext = httpContext;
        }

        public async Task Create(UsuarioViewModel model)
        {

            UsuarioCreateCommand command = _mapper.Map<UsuarioCreateCommand>(model);           
            await _bus.SendCommand(command);
        }

        public async Task Update(UsuarioViewModel model)
        {
            UsuarioEditCommand command = _mapper.Map<UsuarioEditCommand>(model);         
            await _bus.SendCommand(command);
        }

        public async Task<IEnumerable<UsuarioViewModel>> GetAll()
        {
            var users = (await _repository.GetAllUsuarios());
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(users);
        }

        public async Task<IEnumerable<UsuarioViewModel>> GetByFilter()
        {
            var response = (await _repository.GetByFilter());
            return _mapper.ProjectTo<UsuarioViewModel>(response.AsQueryable());
        }

        public async Task<UsuarioViewModel> GetById(Guid id)
        {
            var response = (await _repository.GetById(id));
            return _mapper.Map<UsuarioViewModel>(response);
        }

        public async Task<bool> Delete(Guid id)
        {
            var user = await _repository.GetById(id);
            if (user != null)
            {
                try
                {
                    await _repository.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                try
                {
                    await Delete(user);
                }
                catch (Exception e)
                {
                    Console.WriteLine("MESSAGE: " + e.Message + "\n INNER: " + e.InnerException);
                    return false;
                }

                return true;
            }

            return false;

        }
        private async Task Delete(Usuarios user)
        {
            _repository.Delete(user);
            await _repository.SaveChangesAsync();
        }
    }
}
