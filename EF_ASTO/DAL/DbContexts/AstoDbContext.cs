using EF_ASTO.DAL.DbContexts.EntitiesConfiguration;
using EF_ASTO.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EF_ASTO.DAL.DbContexts
{
    public class AstoDbContext : DbContext
    {
        public DbSet<Row> Rows { get; set; } = null!;
        public DbSet<Column> Columns { get; set; } = null!;
        public DbSet<Cell> Cells { get; set; } = null!;

        public AstoDbContext(DbContextOptions<AstoDbContext> options)
        : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Row>().ToTable("Rows", schema: "asto");
            //modelBuilder.Entity<Column>().ToTable("Columns", schema: "asto");

            //Применениие классов конфигураций по одному классу
            //modelBuilder.ApplyConfiguration(new RowsConfiguration());
            //modelBuilder.ApplyConfiguration(new ColumnConfiguration());
            //modelBuilder.ApplyConfiguration(new EmployeeConfiguration());


            //Так можно применить все классы Конфигураций в сборке
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
