using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA.AcunaPC01.DOMAIN.Core.Entities;
using DPA.AcunaPC01.DOMAIN.Infraestructure.Data;

namespace DPA.AcunaPC01.DOMAIN.Infraestructure.Repositories
{
    internal class CanchaRepository
    {
        private readonly SistemaReservasCanchasContext _context;
        public CanchaRepository(SistemaReservasCanchasContext context)
        {
            _context = context;
        }

        //Get all categories
        public async Task<IEnumerable<Canchas>> GetAllCategories()
        {
            return await _context.Canchas.Where(c => c.IsActive == true).ToListAsync();
        }
        //Get category by id
        public async Task<Canchas> GetCategoryById(int id)
        {
            return await _context.Canchas.Where(c => c.Id == id && c.IsActive == true).FirstOrDefaultAsync();
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
            //existingCategory.IsActive = category.IsActive;
            //_context.Category.Update(existingCategory);
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
        // Delete category by id (remove)
        public async Task<bool> RemoveCategory(int id)
        {
            var cancha = await GetCategoryById(id);
            if (cancha == null)
            {
                return false;
            }
            _context.Canchas.Remove(cancha);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
