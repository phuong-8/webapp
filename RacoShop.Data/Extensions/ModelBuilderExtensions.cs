﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using RacoShop.Data.Entities;

namespace RacoShop.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //data seeding
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key = "HomeTilte", Value = "Home Page" },
                new AppConfig() { Key = "HomeKeyWord", Value = "Home Key Word" },
                new AppConfig() { Key = "HomeDepcription", Value = "Home Depcription" }
                );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id="vn-VN", Name="Tiếng Việt", IsDefault=true},
                new Language() { Id="en-US", Name="EngLish", IsDefault=false}
                );
            modelBuilder.Entity<Category>().HasData(
                new Category() { 
                    Id= 1,
                    IsShowOnHome=true, 
                    ParentId=null, 
                    SortOrder=1, 
                    Status = Enums.Status.Active
                },
                new Category()
                {
                    Id = 2,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Enums.Status.Active
                });
            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation()
                {
                    Id=1,
                    CategoryId=1,
                    Name = "Áo nam",
                    LanguageId = "vn-VN",
                    SeoAlias = "ao-nam",
                    SeoDescription = "Sản phẩm thời trang nam",
                    SeoTitle = "Sản phẩm thời trang nam"
                },
                new CategoryTranslation()
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Men Shirt",
                    LanguageId = "en-US",
                    SeoAlias = "men-shirt",
                    SeoDescription = "The shirt product for men",
                    SeoTitle = "The shirt product for men"
                },
                new CategoryTranslation()
                {
                    Id = 3,
                    CategoryId = 2,
                    Name = "Áo nữ",
                    LanguageId = "vn-VN",
                    SeoAlias = "ao-nu",
                    SeoDescription = "Sản phẩm thời trang nữ",
                    SeoTitle = "Sản phẩm thời trang nữ"
                },
                new CategoryTranslation()
                {
                    Id = 4,
                    CategoryId = 2,
                    Name = "Women Shirt",
                    LanguageId = "en-US",
                    SeoAlias = "women-shirt",
                    SeoDescription = "The shirt product for women",
                    SeoTitle = "The shirt product for women"
                }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id=1,
                    DateCreated = DateTime.Now,
                    OriginalPrice = 100000,
                    Price = 200000,
                    Stock = 0, 
                    ViewCount = 0
                });
            modelBuilder.Entity<ProductTranslation>().HasData(
                new ProductTranslation()
                {
                    Id=1,
                    ProductId=1,
                    Name = "Áo sơ mi trắng",
                    LanguageId = "vn-VN",
                    SeoAlias = "ao-so-mi-trang",
                    SeoDescription = "Áo sơ mi trắng",
                    SeoTitle = "Áo sơ mi trắng",
                    Details = "Áo sơ mi trắng",
                    Description = "Áo sơ mi trắng"
                },
                new ProductTranslation()
                {
                    Id=2,
                    ProductId=1,
                    Name = "white Shirt",
                    LanguageId = "en-US",
                    SeoAlias = "white-shirt",
                    SeoDescription = "white Shirt",
                    SeoTitle = "white Shirt",
                    Details = "white Shirt",
                    Description = "white Shirt"
                }
                );
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory()
                {
                    ProductId=1,
                    CategoryId=1
                }
                );

            var roleId = new Guid("425AC812-3905-4DC3-8958-EDC00B8C4BF7");
            var roleAdmin = new Guid("F5C37570-FCDC-4993-8496-E2C50FBC2923");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "none"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = roleAdmin,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "nvpcntt08@gmail.com",
                NormalizedEmail = "nvpcntt08@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456"),
                SecurityStamp = string.Empty,
                FirstName = "phuong",
                LastName = "nguyen",
                Dob = new DateTime(2000,8,17),
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = roleAdmin
            });
        }
    }
}
