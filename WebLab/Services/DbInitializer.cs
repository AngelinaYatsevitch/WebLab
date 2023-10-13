using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLab.Entities;

namespace WebLab.Data
{
    public static class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context,
                             UserManager<ApplicationUser> userManager,
                             RoleManager<IdentityRole> roleManager)
        {
            // создать БД, если она еще не создана
            context.Database.EnsureCreated();

            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin
                await roleManager.CreateAsync(roleAdmin);
            }

           
            
            
            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                var admin1 = new ApplicationUser
                {
                    Email = "admin1@mail.ru",
                    UserName = "admin1@mail.ru"
                };
                await userManager.CreateAsync(admin1, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }

            //проверка наличия групп объектов
            if (!context.DishGroups.Any())
            {
                context.DishGroups.AddRange(
                new List<DishGroup>
                {
                new DishGroup {GroupName="Бутерброды"},
                new DishGroup {GroupName="Десерты"},
                new DishGroup {GroupName="Напитки"},
                new DishGroup {GroupName="Основные блюда"},
                new DishGroup {GroupName="Завтраки"}
                });
                await context.SaveChangesAsync();
            }
            // проверка наличия объектов
            if (!context.Dishes.Any())
            {
                context.Dishes.AddRange(
                new List<Dish>
                {
                new Dish {DishName="Бутерброды постные",
                Description="Просто бутерброды с яйцом",
                Calories =200, DishGroupId=1, Image="b1.jpg" },
                new Dish {DishName="Бутерброды сладкие",
                Description="С бананом и черникой",
                Calories =330, DishGroupId=1, Image="b2.jpg" },
                new Dish {DishName="Классический бутерброд",
                Description="Хлеб - 80%, Масло - 20%",
                Calories =160, DishGroupId=1, Image="b3.jpg" },


                new Dish {DishName="Круасан",
                Description="Хорошо к чаю",
                Calories =200, DishGroupId=2, Image="d1.jpg" },
                new Dish {DishName="Венские вафли",
                Description="С шариком мороженого",
                Calories =330, DishGroupId=2, Image="d2.jpg" },
                new Dish {DishName="Пончики",
                Description="С шоколодом",
                Calories =160, DishGroupId=2, Image="d3.jpg" },

                new Dish {DishName="Кофе",
                Description="Эспрессо",
                Calories =200, DishGroupId=3, Image="n1.jpg" },
                new Dish {DishName="Сок",
                Description="Апельсиновый",
                Calories =330, DishGroupId=3, Image="n2.jpg" },
                new Dish {DishName="Компот",
                Description="Клубничный",
                Calories =160, DishGroupId=3, Image="n3.jpg" },


                new Dish {DishName="Яичница",
                Description="С овощами",
                Calories =200, DishGroupId=4, Image="os1.jpg" },
                new Dish {DishName="Лаваш",
                Description="С овощами",
                Calories =330, DishGroupId=4, Image="os2.jpg" },



                new Dish {DishName="Творог",
                Description="С клубникой",
                Calories =200, DishGroupId=5, Image="z1.jpg" },
                new Dish {DishName="Хлопья",
                Description="Кукурузные",
                Calories =330, DishGroupId=5, Image="z2.jpg" },
                });
                await context.SaveChangesAsync();
            }

        }
    }
}

