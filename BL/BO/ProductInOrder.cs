using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ProductInOrder
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double BasePrice { get; set; }
        public int Amount { get; set; }
        public List<SaleInProduct> SaleInProduct { get; set; }
        public double FinalPrice { get; set; }

        public ProductInOrder(int productId, string productName, double basePrice, int amount, List<SaleInProduct> saleInProduct, double finalPrice)
        {
            ProductId = productId;
            ProductName = productName;
            BasePrice = basePrice;
            Amount = amount;
            SaleInProduct = saleInProduct ?? new List<SaleInProduct>();
            FinalPrice = finalPrice;
        }
    }
}
    

