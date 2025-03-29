using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BlApi
{
    public interface IOrder
    {
        List<BO.SaleInProduct> AddProductToOrder(BO.Order order, int productId, int amount);
        void CalcTotalPriceForProduct(BO.ProductInOrder product);
        void CalcTotalPrice(BO.Order order);
        void DoOrder(BO.Order order);
        List<BO.SaleInProduct> SearchSaleForProduct(int productId, bool isPreferredCustomer);
    }
}

