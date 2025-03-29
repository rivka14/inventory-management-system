using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Order
    {
        public bool IsPreferredCustomer { get; set; }
        public List<ProductInOrder> ProductInOrder { get; set; }
        public double TotalPrice { get; set; }

        public Order(bool isPreferredCustomer, List<ProductInOrder> products, double totalPrice)
        {
            IsPreferredCustomer = isPreferredCustomer;
            ProductInOrder = products ?? new List<ProductInOrder>();
            TotalPrice = totalPrice;
        }
    }
}
