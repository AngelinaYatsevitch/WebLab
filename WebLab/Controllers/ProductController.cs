﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLab.Entities;

namespace WebLab.Controllers
{
    public class ProductController : Controller
    {
        List<Dish> _dishes;
        List<DishGroup> _dishGroups;
        public ProductController()
        {
            SetupData();
        }
        public IActionResult Index()
        {
            return View(_dishes);
        }
        /// <summary>
        /// Инициализация списков
        /// </summary>
        private void SetupData()
        {
            _dishGroups = new List<DishGroup>
            {
                new DishGroup {DishGroupId=1, GroupName="Бутерброды"},
                new DishGroup {DishGroupId=2, GroupName="Десерты"},
                new DishGroup {DishGroupId=3, GroupName="Напитки"},
                new DishGroup {DishGroupId=4, GroupName="Основные блюда"},
                new DishGroup {DishGroupId=5, GroupName="Завтраки"},
            };
            _dishes = new List<Dish>
            {
                new Dish {DishId = 1, DishName="Бутерброды постные",
                Description="Просто бутерброды с яйцом",
                Calories =200, DishGroupId=1, Image="b1.jpg" },
                new Dish { DishId = 2, DishName="Бутерброды сладкие",
                Description="С бананом и черникой",
                Calories =330, DishGroupId=1, Image="b2.jpg" },
                new Dish { DishId = 3, DishName="Классический бутерброд",
                Description="Хлеб - 80%, Масло - 20%",
                Calories =160, DishGroupId=1, Image="b3.jpg" },


                new Dish {DishId = 4, DishName="Круасан",
                Description="Хорошо к чаю",
                Calories =200, DishGroupId=2, Image="d1.jpg" },
                new Dish { DishId = 5, DishName="Венские вафли",
                Description="С шариком мороженого",
                Calories =330, DishGroupId=2, Image="d2.jpg" },
                new Dish { DishId = 6, DishName="Пончики",
                Description="С шоколодом",
                Calories =160, DishGroupId=2, Image="d3.jpg" },

                new Dish {DishId = 7, DishName="Кофе",
                Description="Эспрессо",
                Calories =200, DishGroupId=3, Image="n1.jpg" },
                new Dish { DishId = 8, DishName="Сок",
                Description="Апельсиновый",
                Calories =330, DishGroupId=3, Image="n2.jpg" },
                new Dish { DishId = 9, DishName="Компот",
                Description="Клубничный",
                Calories =160, DishGroupId=3, Image="n3.jpg" },


                new Dish {DishId = 10, DishName="Яишница",
                Description="С овощами",
                Calories =200, DishGroupId=4, Image="os1.jpg" },
                new Dish { DishId = 11, DishName="Лаваш",
                Description="С овощами",
                Calories =330, DishGroupId=4, Image="os2.jpg" },



                new Dish {DishId = 12, DishName="Творог",
                Description="С клубникой",
                Calories =200, DishGroupId=5, Image="z1.jpg" },
                new Dish { DishId = 13, DishName="Хлопья",
                Description="Кукурузные",
                Calories =330, DishGroupId=5, Image="z2.jpg" },



            };
        }
    }
}
