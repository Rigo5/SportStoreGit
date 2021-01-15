using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entity;
using System.Data.SqlClient;

namespace Domain.Concrete
{

    public class ProductRepository : IProductRepository
    {
        //just read and private connection string 
        private readonly string ConnectionString = @"Server=DESKTOP-H7TIGEP\SQLEXPRESS; Database=Michele_test; Integrated Security=true";
        public IEnumerable<Product> Products => GetProducts();

        private IEnumerable<Product> GetProducts()
        {
            var Products = new List<Product>();
            using(var connection = new SqlConnection(ConnectionString))
            {
                using(var query = new SqlCommand("SELECT TOP (20)* FROM [dbo].[Products]", connection))
                {
                    connection.Open();
                    using(SqlDataReader reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Products.Add(new Product
                            {
                                ProductID = (int)reader["ProductId"],
                                Name = (string)reader["Name"],
                                Description = (string)reader["Description"],
                                Price = (decimal)reader["Price"],
                                Category = (string)reader["Category"]
                            });
                        }
                    }
                }
            }
            return Products;
        }
    }
}
