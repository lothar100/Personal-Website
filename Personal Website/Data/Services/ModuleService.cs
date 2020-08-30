using Microsoft.EntityFrameworkCore;
using Personal_Website.Data.Context;
using Personal_Website.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_Website.Data.Services {
    public class ModuleService {

        public static event Func<Task> OnUpdate;

        private readonly SqlDbContext _context;

        public string TargetId;

        public ModuleService(SqlDbContext context)
        {
            _context = context;
        }

        public async Task<List<PageModuleModel>> GetAll()
        {
            try
            {
                return await _context.Modules.ToListAsync();
            }
            finally
            {
                if(OnUpdate != null)
                {
                    await OnUpdate.Invoke();
                }
            }
        }

        public async Task<PageModuleModel> GetPrev(int sortId)
        {
            return await _context.Modules
                .OrderByDescending(module => module.SortId)
                .FirstOrDefaultAsync(module => module.SortId < sortId);
        }

        public async Task<PageModuleModel> Get(int id)
        {
            return await _context.Modules.FindAsync(id);
        }

        public async Task<PageModuleModel> GetNext(int sortId)
        {
            return await _context.Modules
                .OrderBy(module => module.SortId)
                .FirstOrDefaultAsync(module => module.SortId > sortId);
        }

        public int GetNextId()
        {
            return  _context.Modules
                .OrderByDescending(module => module.Id)
                .Select(module => module.Id)
                .First()
                + 1;
        }

        public async Task<int> AddOrUpdate(PageModuleModel pageModule)
        {
            if (Exists(pageModule.Id))
            {
                return await Update(pageModule.Id, pageModule);
            }
            else
            {
                pageModule.SortId = GetNextId();
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
