using Microsoft.EntityFrameworkCore;
using Personal_Website.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personal_Website.Data.Context {
    public class SqlDbContext : DbContext {

        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }

        public DbSet<PageModuleModel> Modules { get; set; }
    }
}
