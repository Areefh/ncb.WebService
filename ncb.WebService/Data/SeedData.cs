using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ncb.WebService.Models;

namespace ncb.WebService.Data
{
    public sealed class SeedData
    {
        public static void Initialize(GameContext context)
        {
            if (!context.Categories.Any())
            {
                //context.Categories.AddRange(
                //    new Category
                //    {
                //        Name = "Squeaky Bone",
                //        Price = 20.99m
                //    },
                //    new Category
                //    {
                //        Name = "Knotted Rope",
                //        Price = 12.99m
                //    }
                //);

                //context.SaveChanges();
            }
        }
    }
}