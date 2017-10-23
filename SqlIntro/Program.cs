using System;
using System.Linq;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=localhost;Database=adventureworks;Uid=root;Pwd=1234"; //get connectionString format from connectionstrings.com and change to match your database
            var repo = new ProductRepository(connectionString);
            foreach (var prod in repo.GetProducts().Take(1))
            {
                Console.WriteLine("ModifiedDate:" + prod.ModifiedDate.DayOfWeek);
            }



            var product = new Product()
            {
               ProductId = 316,
                Name = "Bladess",
            };

            repo.UpdateProduct(product);
            Console.WriteLine("Product ID 3 changed to Bladess");
            repo.DeleteProduct(4);
            Console.WriteLine("Should have product 4 deleted now");

            var productA = new Product()
            {
                Name = "Very Large Ball Bearings",
                ModifiedDate = DateTime.UtcNow,

            }
            ;

            repo.InsertProduct(productA);
            Console.WriteLine("Inserted new name and modified date time");
            Console.ReadLine();
        }

       
    }
}
