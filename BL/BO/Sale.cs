using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{

    public class Sale
    {
        public int ProductId { get; set; }
        public int AmountForSale { get; set; }
        public int UniqueIdAuto { get; set; }
        public int PriceForSale { get; set; }
        public bool IsForClab { get; set; }
        public DateTime? LastTime { get; set; }
        public DateTime? EndTime { get; set; }

       
        public Sale(int productId, int amountForSale, int uniqueIdAuto, int priceForSale, bool isForClab, DateTime? lastTime, DateTime? endTime)
        {
            ProductId = productId;
            AmountForSale = amountForSale;
            UniqueIdAuto = uniqueIdAuto;
            PriceForSale = priceForSale;
            IsForClab = isForClab;
            LastTime = lastTime;
            EndTime = endTime;
        }
    }

}
