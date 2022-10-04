using Conflitec.Domain.Enuns;
using Conflitec.Domain.Interfaces.Domain;
using Conflitec.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conflitec.Domain.Interfaces.Infra.Data.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuarios>
    {
        Task<IEnumerable<Usuarios>> GetAllUsuarios();
        Task<IEnumerable<Usuarios>> GetByFilter();
        Task<Usuarios> GetById(Guid id);
    }
}
