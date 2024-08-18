using EF_ASTO.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ASTO.DAL.DbContexts.EntitiesConfiguration
{
    internal class CellConfiguration: IEntityTypeConfiguration<Cell>
    {
        public void Configure(EntityTypeBuilder<Cell> builder)
        {
            //Не получилось
            builder.ToTable("Cells", schema: "asto");
            builder.HasKey(p => new { p.RowId, p.ColumnId });
            builder.HasOne(p => p.Row).WithMany(p => p.LinkRowToCell).HasForeignKey(p => p.RowId);

            builder.HasOne(p => p.Column).WithMany(p => p.LinkColumnToCell).HasForeignKey(p => p.ColumnId);
        }
    }
}
