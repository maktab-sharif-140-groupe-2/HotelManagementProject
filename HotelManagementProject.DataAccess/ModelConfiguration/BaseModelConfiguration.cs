using HotelManagementProject.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementProject.DataAccess.ModelConfiguration
{
    public abstract class BaseModelConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasIndex(b => b.CreatedAt);

            builder.Property(b => b.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(b => b.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            ConfigureEntity(builder);
        }
        protected abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);

    }
}
