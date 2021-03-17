using Dapper;
using homework_5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace homework_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperSampleController : ControllerBase
    {
        private readonly ILogger<DapperSampleController> _logger;
        private readonly IConfiguration _configuration;

        public DapperSampleController(ILogger<DapperSampleController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult DapperSelectInQuery([FromQuery] List<int> ids)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }

                /* 
                   Body'den bir id listesi alarak virgül ile ayırarak idList isimli bir değişkene atadım.
                   Bu liste içindeki id'leri tek tek gezdim ve Query metodunu kullanarak database'den dönen Result'ı kendi modelime map ettim.
                     1 - Dynamic : Hangi nesne olduğunu belirtmeden dynamic bir mapping yaptım. Bunun dezavantajı; hata varsa bile Buil anında göremememiz.
                     2 - Order Mapping : Query'den dönen sonucu oluşturduğum Order modelime direkt olarak map ettim.
                */

                string idList = $"{string.Join("," , ids)}";

                string sql = $"SELECT * FROM dbo.Orders IN ({idList});";

                // Dynamic
                var ordersDynamic = db.Query(sql);

                // Order Mapping
                IEnumerable<Order> ordersMapping = db.Query<Order>(sql);
                
                return Ok(ordersMapping);
            }   
        }

        [HttpPost]
        public IActionResult DapperInsert()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }

                // INSERT

                /* 
                   Execute metodu sayesinde oluşturduğum SQL Query'sini ve nesnemi database'e insert ettim.
                   Tek bir Execute metodu çalıştırarak birden fazla insert de gerçekleştirdim (for ile).
                */

                string sql = @"INSERT INTO dbo.Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax)
                                Values (@CustomerID, @CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax);";

                var changed = db.Execute(sql, new
                {
                    CustomerID = "6465",
                    CompanyName = "Yemeksepeti",
                    ContactName = "Pinar",
                    ContactTitle = "Jr. Software Engineer",
                    Address = "Antalya",
                    City = "Ant",
                    Region = "Akdeniz",
                    PostalCode = "07130",
                    Country = "Turkiye",
                    Phone = "055555555",
                    Fax = "djdfjk"
                });

                // INSERT MANY

                /*
                    
                */

                object[] list = new object[10];

                for (var i = 0; i < 10; i++)
                {
                    list[i] = new[]
                    {
                        new
                        {
                            CustomerID = i.ToString(),
                            CompanyName = "Yemeksepeti",
                            ContactName = "Pinar",
                            ContactTitle = "Jr. Software Engineer",
                            Address = "Antalya",
                            City = "Ant",
                            Region = "Akdeniz",
                            PostalCode = "07130",
                            Country = "Turkiye",
                            Phone = "055555555",
                            Fax = "djdfjk"
                        }
                    };
                }

                changed = db.Execute(sql, list);

            }

            return Ok();
        }

        [HttpPut]
        public IActionResult DapperUpdate()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }

                /* 
                   Execute metodu sayesinde oluşturduğum SQL Query'sini ve array olarak aldığım update edilecek değerleri database'e gönderdim.
                */

                string sql = "Update dbo.Customers Set Phone = @Phone Where CustomerID = @CustomerID";

                var paramsArray = new[]
                {
                    new { CustomerID = "6465", Phone = "0000" }
                };

                db.Execute(sql, paramsArray);
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult DapperDelete()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }

                // DELETE

                /* 
                   Execute metodu sayesinde, oluşturulan SQL Query'sini ve delete etmek istediğim Customer'ın Id'sini database'e gönderdim.
                */

                var sql = "Delete From dbo.Customers Where CustomerID = @CustomerID";
                
                db.Execute(sql, new[]
                {
                    new { CustomerID = "6465" }
                });  
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult DapperDeleteInQuery([FromQuery] List<int> ids)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }

                /* 
                   Body'den bir id listesi alarak virgül ile ayırarak idList isimli bir değişkene atadım.
                   Bu liste içindeki id'leri tek tek gezdim ve Execute metodunu kullanarak SQL Query'mi çalıştırdım.
                */

                string idList = $"{string.Join(",", ids)}";

                var sql = $"Delete From dbo.Customers Where CustomerID IN ({idList});";

                db.Execute(sql);
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult DapperStoredProcedure()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }

                /*
                    Database tarafında tüm Customer'ları getirmek için bir Stored Procedure oluşturdum.
                    Query:
                        CREATE PROCEDURE SelectAllCustomers
                        AS
                        SELECT * FROM Customers
                        GO;

                    Bu aşamadan sonra "EXEC" komutunu kullanarak, oluşturduğum procedure'ı çağırdım.
                */

                string procedure = "SelectAllCustomers";
                string sql = $"EXEC {procedure}";

                var customers = db.Query(sql, commandType: CommandType.StoredProcedure).ToList();

                return Ok(customers);
            }
        }

        [HttpPost]
        public IActionResult DapperTransaction()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }

                /*
                    İki tane SQL Query'm var. Transaction sayesinde, eğer herhangi biri çalışmazsa veya hatalı çalışırsa önceki yaptığı işlemi geri alabiliyorum.
                    Bunun için Desposable Pattern (using bloğu) kullanarak bir Transaction başlattım ("BeginTransaction()").
                    Yapmak istediğim işlemleri Execute metoduyla yaptıktan sonra trancastion'ını Commit'lemem gerekiyor.
                */

                using (var transaction = db.BeginTransaction())
                {
                    string sql = @"INSERT INTO dbo.Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax)
                                    Values (@CustomerID, @CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax);";

                    var affected = db.Execute(sql, new
                    {
                        CustomerID = "6465",
                        CompanyName = "Yemeksepeti",
                        ContactName = "Pinar",
                        ContactTitle = "Jr. Software Engineer",
                        Address = "Antalya",
                        City = "Ant",
                        Region = "Akdeniz",
                        PostalCode = "07130",
                        Country = "Turkiye",
                        Phone = "055555555",
                        Fax = "djdfjk"
                    }, transaction);

                    Product product = new Product()
                    {
                        ProductID = 98765,
                        ProductName = "hede hödö",
                        SupplierID = 1,
                        CategoryID = 1,
                        QuantityPerUnit = "something",
                        UnitPrice = 18,
                        UnitsInStock = 5,
                        UnitsOnOrder = 5,
                        ReorderLevel = 5,
                        Discontinued = false
                    };

                    sql = @"INSERT INTO dbo.Products (ProductID, ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)
                                    Values (@ProductID, @ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued);";

                    var changed = db.Execute(sql, product, transaction);

                    transaction.Commit();
                }
            }

            return Ok();
        }


        [HttpGet]
        public IActionResult DapperResultMapping(int id)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }

                /* 
                   Select işlemi gerçekleştiren bir SQL Query'm var. OrderID'nin, integer olarak aldığım id'ye eşit olup olmadığı kontrolünü sağladım.
                   Daha sonra, geri dönen sonucu Models klasörü altında oluşturduğum Order nesneme Query metodu sayesinde map ettim.
                */

                string sql = $"SELECT * FROM dbo.Orders WHERE OrderId = {id};";

                IEnumerable<Order> ordersMapping = db.Query<Order>(sql);

                return Ok(ordersMapping);
            }
        }


        [HttpGet]
        public IActionResult DapperOneToOne(int productId)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }

                /* 
                   Burada bir Product'a ait ProductId ile birbirine bağlı Supplier'ları listeledim. 
                   Dönen sonuçları Dapper'ın Query methodunu kullanarak iki ayrı objeye map ettim. 
                */

                string sql = $"SELECT * FROM dbo.Products pd INNER JOIN dbo.Suppliers sp ON pd.SupplierID = sp.SupplierID WHERE pd.ProductID = {productId};";

                var result = db.Query<Product, Supplier, Product>(sql,
                    map: (product, supplier) => {
                        product.Supplier = supplier;
                        return product; 
                    }).ToList();

                return Ok(result);
            }
        }

        [HttpGet]
        public IActionResult DapperOneToMany(int categoryId)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }

                /* 
                   Burada bir Category'e ait CategoryId ile birbirine bağlı Product'ları listeledim. 
                   Dönen sonuçları Dapper'ın Query methodunu kullanarak iki ayrı objeye map ettim. 
                */

                string sql = $"SELECT * FROM dbo.Categories ct INNER JOIN dbo.Products pd ON ct.CategoryID = pd.CategoryID WHERE ct.CategoryID = {categoryId};";

                var result = db.Query<Category, Product, Category>(sql,
                    map: (category, product) => {
                        product.Category = category;
                        return category;
                    }).ToList();

                return Ok(result);
            }
        }

        [HttpGet]
        public IActionResult DapperMultipleQueryMapping(int supplierId)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }

                /*
                   İki tane query çalıştırmak için Dapper'ın QueryMultiple metodundan faydalandım.
                   Geri dönen iki ayrı nesne için map ettim.
                */

                string sql = $"SELECT * FROM Products WHERE SupplierID = {supplierId}; SELECT * FROM Suppliers WHERE SupplierID = {supplierId};";

                Supplier supplier;

                using (var multi = db.QueryMultiple(sql))
                {
                    supplier = multi.Read<Supplier>().FirstOrDefault();
                    supplier.Products = multi.Read<Product>().ToList();
                }

                return Ok(supplier);
            }
        }
    }
}
