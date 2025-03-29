using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BlApi;
using static BO.Tools;
namespace BlImplementation
{
    public class OrderImplementation :IOrder
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;
        public List<BO.SaleInProduct> AddProductToOrder(BO.Order order, int ProductId, int AmountForSale)
        {
            return new List<BO.SaleInProduct>();

        }
        public void CalcTotalPriceForProduct(BO.ProductInOrder productInOrder)
        {


        }
        public void CalcTotalPrice(BO.Order order)
        {

        }
        public void DoOrder(BO.Order order)
        {

        }
        public List<BO.SaleInProduct> SearchSaleForProduct(int ProductId,bool IsPreferredCustomer) {

            return new List<BO.SaleInProduct>();

        }

    }
}
