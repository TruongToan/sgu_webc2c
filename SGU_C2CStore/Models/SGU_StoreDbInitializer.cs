using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGU_C2CStore.Models
{
    public class SGU_StoreDbInitializer : System.Data.Entity.DropCreateDatabaseAlways<SGU_C2CStoreContext>
    {
        protected override void Seed(SGU_C2CStoreContext context)
        {
            var Categories = new List<Category>()
            {
                new Category() { Id = 1, Name = "Phụ kiện" },
                new Category() { Id = 2, Name = "Điện thoại" },
                new Category() { Id = 3, Name = "Máy tính, laptop" },
                new Category() { Id = 4, Name = "Khác" }
            };
            Categories.ForEach(e => context.Categories.Add(e));
            context.SaveChanges();
        }
    }
}