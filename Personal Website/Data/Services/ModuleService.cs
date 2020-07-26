using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Personal_Website.Data.Context;
using Personal_Website.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_Website.Data.Services {
    public class ModuleService {

        private readonly SqlDbContext _context;

        public ModuleService(SqlDbContext context)
        {
            _context = context;
        }

        public async Task<List<PageModuleModel>> GetAll()
        {
            return await _context.Modules.ToListAsync();
        }

        public async Task<PageModuleModel> Get(int id)
        {
            return await _context.Modules.FindAsync(id);
        }

        public async Task<int> AddOrUpdate(PageModuleModel pageModule)
        {
            if (Exists(pageModule.Id))
            {
                return await Update(pageModule.Id, pageModule);
            }
            else
            {
                return await Insert(pageModule);
            }
        }

        private async Task<int> Insert(PageModuleModel pageModule)
        {
            _context.Modules.Add(pageModule);
            return await _context.SaveChangesAsync();
        }

        private async Task<int> Update(int id, PageModuleModel pageModule)
        {
            var module = await _context.Modules.FindAsync(id);

            if (module == null)
                return default;

            module.Title = pageModule.Title;
            module.Summary = pageModule.Summary;

            _context.Modules.Update(module);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var module = await _context.Modules.FindAsync(id);

            if (module == null)
                return default;

            _context.Modules.Remove(module);
            return await _context.SaveChangesAsync();
        }

        private bool Exists(int id)
        {
            return _context.Modules.Any(m => m.Id == id);
        }

    }
}
