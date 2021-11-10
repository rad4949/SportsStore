using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreRad.Models
{
    public class SeedData
    {
        public static void Initial(ApplicationDbContext content)
        {
            if (!content.Products.Any())
            {
                content.AddRange(
                 new Product
                 {
                     Img= "https://image.zzebra.zone/r/p7j2MOVLp88/fit/550/550/ce/1/plain/images/products/1/1448/390612392/214475_1CI_1.jpg@webp",
                     Name = "Nike Therma Shield Strike",
                     Description = "Поєднання флісового комфорту та водонепроникності",
                     Category = "Штани",
                     Price = 600
                 },
                 new Product
                 {
                     Img = "https://image.zzebra.zone/r/p7j2MOVLp88/fit/550/550/ce/1/plain/images/products/1/1448/390612392/214475_1CI_1.jpg@webp",
                     Name = "Under Armour Vital Woven Pant",
                     Description = "Практичні штани, в яких зручно не лише бігати, а й активно проводити свій час",
                     Category = "Штани",
                     Price = 899
                 },
                 new Product
                 {
                     Img = "https://image.zzebra.zone/r/1p-ojfJCdro/fit/550/550/ce/1/plain/images/products/1/4713/390640233/DU0473_1.jpg@webp",
                     Name = "Under Armour Threadborne Graphic",
                     Description = "Тренувальний джемпер на основі якісного матеріалу",
                     Category = "Худі",
                     Price = 1550.50m
                 },
                 new Product
                 {
                     Img = "https://image.zzebra.zone/r/1p-ojfJCdro/fit/550/550/ce/1/plain/images/products/1/4713/390640233/DU0473_1.jpg@webp",
                     Name = "Adidas Performance",
                     Description = "Класична чорна толстовка",
                     Category = "Худі",
                     Price = 2200
                 },
                 new Product
                 {
                     Img = "https://image.zzebra.zone/r/1p-ojfJCdro/fit/550/550/ce/1/plain/images/products/1/4713/390640233/DU0473_1.jpg@webp",
                     Name = "Adidas Originals Trefoil",
                     Description = "Практичне худі, яке буде корисне для прохолодної погоди",
                     Category = "Худі",
                     Price = 1200
                 },
                 new Product
                 {
                     Img = "https://image.zzebra.zone/r/V8E_7zt5Gcw/fit/550/550/ce/1/plain/images/products/1/7005/484236125/GN3835_1.jpg@webp",
                     Name = "Adidas Tiro 19 Cotton",
                     Description = "Класична футболка-поло на кожен день",
                     Category = "Футболки",
                     Price = 999
                 },
                 new Product
                 {
                     Img = "https://image.zzebra.zone/r/yHWTI4k3e3I/fit/550/550/ce/1/plain/images/products/1/740/464650980/GL8693_1.jpg@webp",
                     Name = "Unsteady Chair",
                     Description = "Secretly give your opponent а disadvantage",
                     Category = "Куртки",
                     Price = 29.95m
                 },
                 new Product
                 {
                     Img = "https://image.zzebra.zone/r/V8E_7zt5Gcw/fit/550/550/ce/1/plain/images/products/1/7005/484236125/GN3835_1.jpg@webp",
                     Name = "Lotto POLO FIRENZE",
                     Description = "Класична футболка-поло",
                     Category = "Футболки",
                     Price = 450
                 },
                 new Product
                 {
                     Img = "https://image.zzebra.zone/r/V8E_7zt5Gcw/fit/550/550/ce/1/plain/images/products/1/7005/484236125/GN3835_1.jpg@webp",
                     Name = "Select Torino T-Shirt",
                     Description = "Футболка для повсякденного носіння",
                     Category = "Футболки",
                     Price = 600
                 });
            }
            content.SaveChanges();
        }
    }
}
