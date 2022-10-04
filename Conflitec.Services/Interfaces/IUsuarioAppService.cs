using Conflitec.Domain.Enuns;
using Conflitec.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conflitec.Services.Interfaces
{
    public interface IUsuarioAppService
    {
        Task Create(UsuarioViewModel model);
        Task Update(UsuarioViewModel model);
        Task<IEnumerable<UsuarioViewModel>> GetAll();
        Task<IEnumerable<UsuarioViewModel>> GetByFilter();
        Task<UsuarioViewModel> GetById(Guid id);
        Task<bool> Delete(Guid id);
    }
}