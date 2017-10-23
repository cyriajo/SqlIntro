using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SqlIntro
{
    public class ProductRepository
    

     
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        /// <summary>
        /// Reads all the products from the products table
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select Modifieddate from product "; //TODO:  Write a SELECT statement that gets all products
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    yield return new Product
                    {
                        ModifiedDate = (DateTime)dr["ModifiedDate"],
                    };
                }
            }
        }

        /// <summary>
        /// Deletes a Product from the database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProduct(int id)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "Delete from product where productid = " + id; //Write a delete statement that deletes by id
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Updates the Product in the database
        /// </summary>
        /// <param name="prod"></param>
        public void UpdateProduct(Product prod)
        {
            //This is annoying and unnecessarily tedious for large objects.
            //More on this in the future...  Nothing to do here..
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "update product set name = 'Bladess' where ProductID =316";
                cmd.Parameters.AddWithValue("Bladess",prod.Name);
                cmd.Parameters.AddWithValue("316", prod.ProductId);
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Inserts a new Product into the database
        /// </summary>
        /// <param name="prod"></param>
        public void InsertProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT into product (name) values(@jackj)";
                cmd.Parameters.AddWithValue("@name", prod.Name);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
