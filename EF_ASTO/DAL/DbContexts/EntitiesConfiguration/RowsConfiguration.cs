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
    internal class RowsConfiguration : IEntityTypeConfiguration<Row>
    {
        public void Configure(EntityTypeBuilder<Row> builder)
        {
            builder.ToTable("Rows", schema: "asto");
            builder.Property(p => p.RowName).HasMaxLength(256).IsRequired();
            //builder.Property(p => p.RowName).HasMaxLength(256).IsRequired().UseCollation("SQL_Latin1_General_CP1_CI_AS");
        }
    }
}
