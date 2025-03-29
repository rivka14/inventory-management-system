using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? Price { get; set; }
        public int? Amount { get; set; }
        public Category? CategoryProduct { get; set; }
        public List<SaleInProduct> SaleInProduct { get; set; }

        public Product(int productId, string productName,Category? c ,int? price, int? amount)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            Amount = amount;
            CategoryProduct = Category.Pictures;
            SaleInProduct = new List<SaleInProduct>(); 
        }
    }


}
