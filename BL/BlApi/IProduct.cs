using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlApi
{
    public interface IProduct
    {
        int Create(BO.Product product);
        BO.Product? Read(int id);
        List<BO.Product?> ReadAll(Func<BO.Product, bool>? filter = null);
        void Update(BO.Product product);
        void Delete(int id);
        List<BO.SaleInProduct> GetActiveSales(int productId, bool isPreferredCustomer);
    }
}



