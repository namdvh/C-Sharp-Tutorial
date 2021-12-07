using eShopSolution.Data.Entities;
using eShopSolution.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(new AppConfig()
            {
                Key = "HomeTitle",
                Value = "This is homepage of eShopSolution"
            }, new AppConfig()
            {
                Key = "HomeKeyWord",
                Value = "This is keyword of eShopSolution"
            }, new AppConfig()
            {
                Key = "HomeDescription",
                Value = "This is description of eShopSolution"
            }
           );
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    OriginalPrice = 100000,
                    Price = 200000,
                    Stock = 0,
                    ViewCount = 0,
                }
              );
            modelBuilder.Entity<ProductTranslation>().HasData(
                new ProductTranslation()
                {
                    Id=1,
                    ProductId = 1,
                    Name = "Áo sơ mi Nam trắng Việt tiến",
                    LanguageId = "vi-VN",
                    SeoAlias = "ao-so-mi-nam-trang-viet-tien",
                    SeoDescription = "Áo sơ mi Nam trắng Việt tiến",
                    SeoTitle = "Áo sơ mi Nam trắng Việt tiến",
                    Details = "Áo sơ mi Nam trắng Việt tiến",
                    Description = "Áo sơ mi Nam trắng Việt tiến"
                },
                    new ProductTranslation()
                    {
                        Id=2,
                        ProductId = 1,
                        Name = "Viet Tien Men T-Shirt",
                        LanguageId = "en-US",
                        SeoAlias = "viet-tien-men-t-shirt",
                        SeoDescription = "Viet Tien Men T-Shirt",
                        SeoTitle = "Viet Tien Men T-Shirt",
                        Details = "Viet Tien Men T-Shirt",
                        Description = "Viet Tien Men T-Shirt"
                    }
                );
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory()
                {
                    ProductId = 1,
                    CategoryId=1,
                }
                );
            modelBuilder.Entity<Language>().HasData(new Language()
            {
                Id = "vi-VN",
                Name = "Tiếng Việt",
                IsDefault = true
            }, new Language() { Id = "en-US", Name = "English", IsDefault = false }
                );
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active,
                },
                 new Category()
                 {
                     Id = 2,
                     IsShowOnHome = true,
                     ParentId = null,
                     SortOrder = 2,
                     Status = Status.Active,
                 }
            );
            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation()
                {
                    Id=1,
                    CategoryId = 1,
                    Name = "Áo Nam",
                    LanguageId = "vi-VN",
                    SeoAlias = "ao-nam",
                    SeoDescription = "Sản phẩm áo thời trang nam",
                    SeoTitle = "Sản phẩm áo thời trang nam"
                },
                    new CategoryTranslation()
                    {
                        Id=2,
                        CategoryId = 1,
                        Name = "Men shirt",
                        LanguageId = "en-US",
                        SeoAlias = "men-shirt",
                        SeoDescription = "The shirt products for men",
                        SeoTitle = "The shirt products for men"

                    },
                    new CategoryTranslation()
                    {
                        Id=3,
                        CategoryId = 2,
                        Name = "Áo nữ",
                        LanguageId = "vi-VN",
                        SeoAlias = "ao-nam",
                        SeoDescription = "Sản phẩm áo thời trang nữ",
                        SeoTitle = "Sản phẩm áo thời trang nữ"
                    },
                    new CategoryTranslation()
                    {
                        Id=4,
                        CategoryId = 2,
                        Name = "Women Shirt",
                        LanguageId = "en-US",
                        SeoAlias = "women-shirt",
                        SeoDescription = "The shirt products for women",
                        SeoTitle = "The shirt products for women"
                    }
                    );
            var roleId = new Guid("20EFD516-F16C-41B3-B11D-BC908CD20565");
            var adminId = new Guid("D5A918C6-5ED4-43EB-BCDF-042594AE26CF");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id= roleId,
                Name="admin",
                NormalizedName="admin",
                Description="Administrator role"
            });
            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName="admin",
                NormalizedUserName="admin",
                Email="doanvuhoainam15@gmail.com",
                NormalizedEmail= "doanvuhoainam15@gmail.com",
                EmailConfirmed=true,
                PasswordHash=hasher.HashPassword(null,"abcd1234$"),
                SecurityStamp=string.Empty,
                FirstName="Toan",
                LastName="Bach",
                Dob=new DateTime(2021,07,12)

            });
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId,
            });
        }

        
    }
}
