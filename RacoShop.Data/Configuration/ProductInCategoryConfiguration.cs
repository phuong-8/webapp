﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using RacoShop.Data.Entities;

namespace RacoShop.Data.Configuration
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.HasKey(x => new { x.CategoryId, x.ProductId });
            builder.ToTable("ProductIncategories");
            builder.HasOne(x => x.Product).WithMany(pc=>pc.ProductInCategories)
                .HasForeignKey(pc=>pc.ProductId);
            builder.HasOne(x => x.Category).WithMany(pc => pc.ProductInCategories)
               .HasForeignKey(pc => pc.CategoryId);
        }
    }
}
