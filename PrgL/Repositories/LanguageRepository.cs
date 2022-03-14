using Microsoft.EntityFrameworkCore;
using PrgL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrgL.Repositories
{
    public class LanguageRepository : GenericRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(DataContext context)
            : base(context)
        { }

        public override async Task<IEnumerable<Language>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public override async Task Update(Language entity)
        {
            var existing = await dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

            existing.Name = entity.Name;
            existing.Creator = entity.Creator;
            existing.Year = entity.Year;
        }

        public override async Task Delete(int id)
        {
            var existing = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();

            dbSet.Remove(existing);
        }
    }
}
