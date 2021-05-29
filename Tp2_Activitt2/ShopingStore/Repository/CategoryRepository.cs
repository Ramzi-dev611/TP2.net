using ShoppingStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingStore.Repository
{
    class CategoryRepository
    {
        private Context context;

        public CategoryRepository()
        {
            context = new Context();
        }

        public void Add(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Category category = context.Categories.SingleOrDefault(c => c.CategoryId == id);
            if (category != null) context.Categories.Remove(category);
            context.SaveChanges();
        }

        public void Update(Category category)
        {
            Category updated = context.Categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);
            if (updated != null)
            {
                // change values of fields
            }

            context.SaveChanges();
        }

        public Category FindById(int id)
        {
            return context.Categories.SingleOrDefault(c => c.CategoryId == id);
        }

        public List<Order> FindAll()
        {
            return context.Orders.ToList();
        }
    }
}
