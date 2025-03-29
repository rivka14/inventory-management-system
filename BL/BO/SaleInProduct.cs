using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class SaleInProduct
    {
        public int SaleId { get; set; }
        public int SaleAmount { get; set; }
        public double SalePrice { get; set; }
        public bool IsForClab { get; set; }

        public SaleInProduct(int saleId, int saleAmount, double salePrice, bool isForClab)
        {
            SaleId = saleId;
            SaleAmount = saleAmount;
            SalePrice = salePrice;
            IsForClab = isForClab;
        }
    }
}
