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
                     Brand = "Nike",
                     Title= "Therma Shield Strike",
                     Description = "Поєднання флісового комфорту та водонепроникності",
                     Category = "Штани",
                     Price = 600
                 },
                 new Product
                 {
                     Img = "https://image.zzebra.zone/r/p7j2MOVLp88/fit/550/550/ce/1/plain/images/products/1/1448/390612392/214475_1CI_1.jpg@webp",
                     Brand = "Under Armour",
                     Title = "Armour Vital Woven Pant",
                     Description = "Практичні штани, в яких зручно не лише бігати, а й активно проводити свій час",
                     Category = "Штани",
                     Price = 899
                 },
                 new Product
                 {
                     Img = "https://image.zzebra.zone/r/1p-ojfJCdro/fit/550/550/ce/1/plain/images/products/1/4713/390640233/DU0473_1.jpg@webp",
                     Brand = "Under Armour",
                     Title = "Threadborne Graphic",
                     Description = "Тренувальний джемпер на основі якісного матеріалу",
                     Category = "Худі",
                     Price = 1550.50m
                 },
                 new Product
                 {
                     Img = "https://image.zzebra.zone/r/1p-ojfJCdro/fit/550/550/ce/1/plain/images/products/1/4713/390640233/DU0473_1.jpg@webp",
                     Brand = "Adidas",
                     Title = "Performance Sport",
                     Description = "Класична чорна толстовка",
                     Category = "Худі",
                     Price = 2500
                 },
                 new Product
                 {
                     Img = "https://image.zzebra.zone/r/1p-ojfJCdro/fit/550/550/ce/1/plain/images/products/1/4713/390640233/DU0473_1.jpg@webp",
                     Brand = "Adidas",
                     Title = "Performance",
                     Description = "Класична чорна толстовка",
                     Category = "Худі",
                     Price = 2200
                 },
                 new Product
                 {
                     Img = "https://image.zzebra.zone/r/1p-ojfJCdro/fit/550/550/ce/1/plain/images/products/1/4713/390640233/DU0473_1.jpg@webp",
                     Brand = "Adidas",
                     Title = "Originals Trefoil",
                     Description = "Практичне худі, яке буде корисне для прохолодної погоди",
                     Category = "Худі",
                     Price = 1200
                 },
                 new Product
                 {
                     Img = "https://image.zzebra.zone/r/V8E_7zt5Gcw/fit/550/550/ce/1/plain/images/products/1/7005/484236125/GN3835_1.jpg@webp",
                     Brand = "Adidas",
                     Title = "Tiro 19 Cotton",
                     Description = "Класична футболка-поло на кожен день",
                     Category = "Футболки",
                     Price = 999
                 },
                 new Product
                 {
                     Img = "https://image.zzebra.zone/r/yHWTI4k3e3I/fit/550/550/ce/1/plain/images/products/1/740/464650980/GL8693_1.jpg@webp",
                     Brand = "Unsteady",
                     Title = "Chair",
                     Description = "Зручна у використані",
                     Category = "Куртки",
                     Price = 29.95m
                 },
                 new Product
                 {
                     Img = "https://image.zzebra.zone/r/V8E_7zt5Gcw/fit/550/550/ce/1/plain/images/products/1/7005/484236125/GN3835_1.jpg@webp",
                     Brand = "Lotto",
                     Title = "POLO FIRENZE",
                     Description = "Класична футболка-поло",
                     Category = "Футболки",
                     Price = 450
                 },
                 new Product
                 {
                     Img = "https://image.zzebra.zone/r/V8E_7zt5Gcw/fit/550/550/ce/1/plain/images/products/1/7005/484236125/GN3835_1.jpg@webp",
                     Brand = "Select",
                     Title = "Torino T-Shirt",
                     Description = "Футболка для повсякденного носіння",
                     Category = "Футболки",
                     Price = 600
                 },
                 new Product
                 {
                     Img = "https://image.zzebra.zone/r/V8E_7zt5Gcw/fit/550/550/ce/1/plain/images/products/1/7005/484236125/GN3835_1.jpg@webp",
                     Brand = "Select",
                     Title = "Torino Montecarlo T-Shirt",
                     Description = "Футболка для повсякденного носіння",
                     Category = "Футболки",
                     Price = 800
                 }
                 );
            }
            content.SaveChanges();
        }
    }
}
