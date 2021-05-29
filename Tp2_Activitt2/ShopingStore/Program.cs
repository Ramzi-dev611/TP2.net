using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingStore.Model;
using ShoppingStore.Repository;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductRepository prodRepo = new ProductRepository();
            CategoryRepository catRepo = new CategoryRepository();
            OrderRepository ordRepo = new OrderRepository();
            
            Order o1 = new Order();
            Order o2 = new Order();

            Category cat1 = new Category();
            Category cat2 = new Category();

            Product p = new Product();

            p.ProductOrder = o1;
            p.ProductCategory = cat1;

            prodRepo.Add(p);

            foreach(var looper in catRepo.FindAll())
            {
                Console.WriteLine(looper);
            }

            Console.WriteLine("------------------------------");

            foreach (var looper in ordRepo.FindAll())
            {
                Console.WriteLine(looper);
            }

            Console.WriteLine("------------------------------");


            foreach (var looper in prodRepo.FindAll())
            {
                Console.WriteLine(looper);
            }

            Console.WriteLine("------------------------------");


            p = prodRepo.FindById(2);

            o1 = ordRepo.FindById(4);
            
            
            cat1 = catRepo.FindById(4);

            p.ProductCategory = cat2;
            p.ProductOrder = o2;

            prodRepo.Update(p);

            ordRepo.Delete(o1.OrderId);

            ordRepo.Delete(cat1.CategoryId);

            foreach (var looper in catRepo.FindAll())
            {
                Console.WriteLine(looper);
            }

            Console.WriteLine("------------------------------");

            foreach (var looper in ordRepo.FindAll())
            {
                Console.WriteLine(looper);
            }

            Console.WriteLine("------------------------------");


            foreach (var looper in prodRepo.FindAll())
            {
                Console.WriteLine(looper);
            }

            Console.WriteLine("------------------------------");

            Console.ReadKey();

        }
    }
}
