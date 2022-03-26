using System;
using Entity.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Entity
{
    class Repository
    {
        private readonly ProductDB db;
        public Repository()
        {
            this.db = new ProductDB();
        }
        public void AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }
        public Product GetProduct(int id)
        {
            return db.Products.Find(id);
        }
        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public void Delete(int pid)
        {
            db.Products.Remove(db.Products.Find(pid));
            db.SaveChanges();
        }
        public void EditProduct(Product editProduct)
        {
            db.Products.Update(editProduct);
            db.SaveChanges();
        }
        public void PlaceOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

    }
    class Program
    {               
        static void Main(string[] args)
        {
            Console.WriteLine("1.AddProduct");
            Console.WriteLine("2.GetProduct");
            Console.WriteLine("3.GetAllProduct");
            Console.WriteLine("4.DeleteProduct");
            Console.WriteLine("5.EditProduct");
            Console.WriteLine("6.PlaceProduct");
            Repository r = new Repository();

            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    {
                        Product product = new Product();
                        Console.WriteLine("Enter ProductName");
                        product.ProductName = Console.ReadLine();
                        Console.WriteLine("Enter the product price");
                        product.Price = double.Parse(Console.ReadLine());
                        r.AddProduct(product);
                    }break;

                case 2:
                    {
                        Console.WriteLine("Enter Id");
                        int id = int.Parse(Console.ReadLine());
                        Product product = r.GetProduct(id);
                        Console.WriteLine($"Id: {product.ProductId} Name: {product.ProductName} Price: {product.Price}");
                    }break;
                case 3:
                    {
                        foreach(Product p in r.GetProducts())
                        {
                            Console.WriteLine($"Id: {p.ProductId} Name: {p.ProductName} Price: {p.Price}");
                        }
                    }break;
                case 4:
                    {
                        Console.WriteLine("Enter Id");
                        r.Delete(int.Parse(Console.ReadLine()));
                    }break;
                case 5:
                    {
                        Product p = new Product();
                        Console.WriteLine("Enter ProductId");
                        p.ProductId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter ProductName");
                        p.ProductName = Console.ReadLine();
                        Console.WriteLine("Enter Product Price");
                        p.Price = double.Parse(Console.ReadLine());
                        r.EditProduct(p);
                    }break;
                case 6:
                    {
                        Order placeOrder = new Order();
                        Console.WriteLine("Enter Product Id");
                        placeOrder.ProductId = int.Parse(Console.ReadLine());
                        placeOrder.OrderDate = DateTime.Now;
                        r.PlaceOrder(placeOrder);
                        Console.WriteLine("Order successful");
                    }break;
            }
        }
    }    
}
