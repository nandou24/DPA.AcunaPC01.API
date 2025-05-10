using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA.AcunaPC01.DOMAIN.Core.Entities;
using DPA.AcunaPC01.DOMAIN.Core.Interfaces;
using DPA.AcunaPC01.DOMAIN.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DPA.AcunaPC01.DOMAIN.Infraestructure.Repositories
{
    internal class CanchaRepository : ICanchaRepository
    {
        private readonly SistemaReservasCanchasContext _context;
        public CanchaRepository(SistemaReservasCanchasContext context)
        {
            _context = context;
        }

        //Get all categories
        public async Task<IEnumerable<Canchas>> GetAllCategories()
        {
            return await _context.Canchas.ToListAsync();
        }
        //Get category by id
        public async Task<Canchas> GetCategoryById(int id)
        {
            return await _context.Canchas.FirstOrDefaultAsync(c => c.Id == id);
        }
        //Add category
        public async Task<int> AddCategory(Canchas canchas)
        {
            await _context.Canchas.AddAsync(canchas);
            await _context.SaveChangesAsync();
            return canchas.Id;
        }

        //Update category
        public async Task<bool> UpdateCategory(Canchas canchas)
        {
            var existingCategory = await GetCategoryById(canchas.Id);
            if (existingCategory == null)
            {
                return false;
            }
            existingCategory.Nombre = canchas.Nombre;
            existingCategory.Ubicacion = canchas.Ubicacion;
            existingCategory.Tipo = canchas.Tipo;

            await _context.SaveChangesAsync();
            return true;
        }

        //Delete category
        public async Task<bool> DeleteCategory(int id)
        {
            var cancha = await GetCategoryById(id);
            if (cancha == null)
            {
                return false;
            }
            _context.Canchas.Update(cancha);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
