using ShoppingStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingStore.Repository
{
    class ProductRepository
    {
        private Context context;

        public ProductRepository()
        {
            context = new Context();
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Product product = context.Products.SingleOrDefault(p => p.ProductId == id);
            if (product != null) context.Products.Remove(product);
            context.SaveChanges();
        }

        public void Update(Product product)
        {
            Product updated = context.Products.SingleOrDefault(p => p.ProductId == product.ProductId);
            if (updated != null)
            {
                updated.ProductCategory = product.ProductCategory;
                updated.ProductOrder = product.ProductOrder;
            }

            context.SaveChanges();
        }

        public Product FindById(int id)
        {
            return context.Products.SingleOrDefault(p => p.ProductId == id);
        }

        public List<Product> FindAll()
        {
            return context.Products.ToList();
        }
    }
}
