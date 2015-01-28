using System.Data.SqlClient;
using DapperExtensions;
using DIPatterns.Factory.Contracts.DataContracts;
using DIPatterns.Factory.Contracts.Interfaces;

namespace DIPatterns.Factory.Accessors
{
    class ProductAccessor : IProductAccessor
    {
        public Product Save(string connString, Product product)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                if (product.Id == 0)
                {
                    //create a new product
                    product.Id = conn.Insert(product);
                }
                else
                {
                    conn.Update(product);
                }

                return product;
            }
        }
    }
}
