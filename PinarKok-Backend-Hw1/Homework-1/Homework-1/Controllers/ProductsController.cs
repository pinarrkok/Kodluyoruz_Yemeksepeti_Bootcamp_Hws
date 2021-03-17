using Homework_1.Model;
using Homework_1.Service;
using Homework_1.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductsController()
        {
            _productService = ProductService.Instance;
        }

        [HttpGet]
        public List<Product> GetAll()
        {
            return _productService.GetAll();
        }

        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            return _productService.GetById(id);
        }

        [HttpPost]
        public ActionResult Add([FromBody] Product product)
        {
            _productService.Add(product);
            return StatusCode(201);
        }

        [HttpPut]
        public void Update([FromBody] Product product)
        {
            _productService.Update(product);
        }

        [HttpOptions]
        public ActionResult Options()
        {
            Response.Headers.Add("Allow","GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
