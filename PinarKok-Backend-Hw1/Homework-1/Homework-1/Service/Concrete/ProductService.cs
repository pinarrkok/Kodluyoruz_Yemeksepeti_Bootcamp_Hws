using Homework_1.Model;
using Homework_1.Repository;
using Homework_1.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_1.Service
{
    public class ProductService : IProductService
    {
        private static volatile ProductService _instance = null;
        private static readonly object padLock = new object();

        public static ProductService Instance
        {
            get
            {
                lock (padLock)
                {
                    if (_instance == null)
                    {
                        _instance = new ProductService();
                    }
                }
                return _instance;
            }
        }

        private readonly ProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = ProductRepository.Instance;
        }

        public void Add(Product product)
        {
            _productRepository.Add(product);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
           return  _productRepository.GetById(id);
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }

        public void Remove(int id)
        {
            _productRepository.Remove(id);
        }
    }
}
