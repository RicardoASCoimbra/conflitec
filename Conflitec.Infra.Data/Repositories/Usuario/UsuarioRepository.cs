using Conflitec.Domain.Enuns;
using Conflitec.Domain.Interfaces.Infra.Data.Repositories;
using Conflitec.Domain.Models;
using Conflitec.Infra.Data.Configuration;
using Conflitec.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Conflitec.Infra.Data.Repositories.Usuario
{
    public class UsuarioRepository : RepositoryBase<Usuarios>, IUsuarioRepository
    {
        public UsuarioRepository(ConflitecDB context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuarios>> GetAllUsuarios()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }


        public async Task<IEnumerable<Usuarios>> GetByFilter()
        {
            IQueryable<Usuarios> query =
                DbSet.Where(x => !x.Excluido);
            return await query.AsNoTracking().ToListAsync();
        }


        public async Task<Usuarios> GetById(Guid id)
        {
            return await _context.Set<Usuarios>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}