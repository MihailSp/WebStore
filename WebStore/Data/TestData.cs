﻿using WebStore.Domain.Entities;

namespace WebStore.Data
{
    public class TestData
    {
        ///<summary>Сотрудники</summary>
        public static ICollection<Employee> Employees { get; } = new List<Employee>
        {
            new () { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 23 },
            new () { Id = 2, LastName = "Петров", FirstName = "Петр", Patronymic = "Петрович", Age = 27 },
            new () { Id = 3, LastName = "Сидоров", FirstName = "Сидор", Patronymic = "Сидорович", Age = 18 }
        };


        ///<summary>Секции</summary>
        public static IEnumerable<Section> Sections { get; } = new[]
         {
            new Section { Id = 1, Name = "Спорт", Order = 0 },
            new Section { Id = 2, Name = "Nike", Order = 0, ParentId = 1 },
            new Section { Id = 3, Name = "Under Armour", Order = 1, ParentId = 1 },
            new Section { Id = 4, Name = "Adidas", Order = 2, ParentId = 1 },
            new Section { Id = 5, Name = "Puma", Order = 3, ParentId = 1 },
            new Section { Id = 6, Name = "ASICS", Order = 4, ParentId = 1 },
            new Section { Id = 7, Name = "Для мужчин", Order = 1 },
            new Section { Id = 8, Name = "Fendi", Order = 0, ParentId = 7 },
            new Section { Id = 9, Name = "Guess", Order = 1, ParentId = 7 },
            new Section { Id = 10, Name = "Valentino", Order = 2, ParentId = 7 },
            new Section { Id = 11, Name = "Диор", Order = 3, ParentId = 7 },
            new Section { Id = 12, Name = "Версачи", Order = 4, ParentId = 7 },
            new Section { Id = 13, Name = "Армани", Order = 5, ParentId = 7 },
            new Section { Id = 14, Name = "Prada", Order = 6, ParentId = 7 },
            new Section { Id = 15, Name = "Дольче и Габбана", Order = 7, ParentId = 7 },
            new Section { Id = 16, Name = "Шанель", Order = 8, ParentId = 7 },
            new Section { Id = 17, Name = "Гуччи", Order = 9, ParentId = 7 },
            new Section { Id = 18, Name = "Для женщин", Order = 2 },            
            new Section { Id = 19, Name = "Fendi", Order = 0, ParentId = 18 },
            new Section { Id = 20, Name = "Guess", Order = 1, ParentId = 18 },
            new Section { Id = 21, Name = "Valentino", Order = 2, ParentId = 18 },
            new Section { Id = 22, Name = "Dior", Order = 3, ParentId = 18 },
            new Section { Id = 23, Name = "Versace", Order = 4, ParentId = 18 },
            new Section { Id = 24, Name = "Для детей", Order = 3 },
            new Section { Id = 25, Name = "Мода", Order = 4 },
            new Section { Id = 26, Name = "Для дома", Order = 5 },
            new Section { Id = 27, Name = "Интерьер", Order = 6 },
            new Section { Id = 28, Name = "Одежда", Order = 7 },
            new Section { Id = 29, Name = "Сумки", Order = 8 },
            new Section { Id = 30, Name = "Обувь", Order = 9 },
        };

        ///<summary>Бренды</summary>
        public static IEnumerable<Brand> Brands { get; } = new[]
        {            
            new Brand { Id = 1, Name = "Acne", Order = 0 },
            new Brand { Id = 2, Name = "Grune Erde", Order = 1 },
            new Brand { Id = 3, Name = "Albiro", Order = 2 },
            new Brand { Id = 4, Name = "Ronhill", Order = 3 },
            new Brand { Id = 5, Name = "Oddmolly", Order = 4 },
            new Brand { Id = 6, Name = "Boudestijn", Order = 5 },
            new Brand { Id = 7, Name = "Rosch creative culture", Order = 6 },
        };

        ///<summary>Продукты</summary>
        public static IEnumerable<Product> Products { get; } = new[]
        {            
            new Product { Id = 1,  Name = "Белое платье",   Price= 725,  ImageUrl="product1.jpj",  Order = 0,  SectionId=2,   BrandId=1},
            new Product { Id = 2,  Name = "Розовое платье", Price= 825,  ImageUrl="product2.jpj",  Order = 1,  SectionId=2,   BrandId=1},
            new Product { Id = 3,  Name = "Красное платье", Price= 625,  ImageUrl="product3.jpj",  Order = 2,  SectionId=2,   BrandId=1},
            new Product { Id = 4,  Name = "Джинсы",         Price= 1125, ImageUrl="product4.jpj",  Order = 3,  SectionId=2,   BrandId=1},
            new Product { Id = 5,  Name = "Легкая майка",   Price= 225,  ImageUrl="product5.jpj",  Order = 4,  SectionId=2,   BrandId=2},
            new Product { Id = 6,  Name = "Легкое голубое поло", Price= 925, ImageUrl="product6.jpj", Order = 5, SectionId=2, BrandId=1},
            new Product { Id = 7,  Name = "Платье белое",   Price= 525,  ImageUrl="product7.jpj",  Order = 6,  SectionId=2,   BrandId=1},
            new Product { Id = 8,  Name = "Костюм кролика", Price= 1225, ImageUrl="product8.jpj",  Order = 7,  SectionId=25,  BrandId=1},
            new Product { Id = 9,  Name = "Красное китайское платье", Price= 805, ImageUrl="product19.jpj", Order = 8, SectionId=25, BrandId=1},
            new Product { Id = 10, Name = "Женские джинсы", Price= 1005, ImageUrl="product10.jpj", Order = 9,  SectionId=25,  BrandId=3},
            new Product { Id = 11, Name = "Джинсы женские", Price= 1000, ImageUrl="product11.jpj", Order = 10, SectionId=25,  BrandId=3},
            new Product { Id = 12, Name = "Летний костюм",  Price= 795,  ImageUrl="product12.jpj", Order = 11, SectionId=25,  BrandId=3},
        };
    }
}
