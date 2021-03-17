using Homework_1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Homework_1.Repository
{
    public class ProductRepository
    {
        private static volatile ProductRepository _instance = null;
        private static readonly object padLock = new object();

        public List<Product> products = new List<Product>();
        private static string FILE_NAME = "products.json";

        public static ProductRepository Instance
        {
            get
            {
                lock (padLock)
                {
                    if (_instance == null)
                    {
                        _instance = new ProductRepository();
                    }
                }
                return _instance;
            }
        }

        private ProductRepository()
        {
            if (File.Exists(FILE_NAME))
            {
                products = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(FILE_NAME));
            }
            else
            {
                FillData();
            }
        }

        private void SynchronizeJsonFile()
        {
            File.WriteAllText(FILE_NAME, JsonSerializer.Serialize(products));
        }

        public void Add(Product product)
        {
            products.Add(product);
            SynchronizeJsonFile();
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public Product GetById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Product product)
        {
            int index = products.FindIndex(p => p.Id == product.Id);
            products[index] = product;
            SynchronizeJsonFile();
        }

        public void Remove(int id)
        {
            products.Remove(products.FirstOrDefault(p => p.Id == id));
            SynchronizeJsonFile();
        }

        private void FillData()
        {
            for (int i = 1; i <= 10; i++)
            {
                Add(new Product
                {
                    Id = i,
                    Name = "Product_" + i,
                    Price = 100 + (i * 10)
                });
            }
        }

    }
}

