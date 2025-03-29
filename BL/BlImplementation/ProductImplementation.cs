
using System;
using System.Collections.Generic;
using System.Linq;
using static BO.Tools;
using BlApi;

namespace BlImplementation
{
    public class ProductImplementation : IProduct
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public int Create(BO.Product Product)
        {
            try
            {
                DO.Product ProductDO = Product.ConvertToDoProduct();
                return _dal.Product.Creat(ProductDO);

            }
            //catch (DalException ex)
            //{
            //    throw new BOException("Error while creating Product.", ex);
            //}
            catch (Exception ex)
            {
                throw new Exception("jty");
            }
        }

        public BO.Product? Read(int id)
        {
            try
            {
                DO.Product ProductDO = _dal.Product.Read(id);
                if (ProductDO == null)
                    return null;
                return ProductDO.ConvertToBoProduct();
            }
            catch (Exception ex)
            {
                //throw new BOException("Error while reading Product.", ex);
                throw new Exception("ex");
            }
        }
        //public BO.Product? Read(Func<BO.Product, bool>? filter = null)
        //{
        //    try
        //    {
        //        DO.Product ProductDO = _dal.Product.Read(i=>i.ProductId==filter());
        //        if (ProductDO == null)
        //            return null;
        //        return ProductDO.ConvertToBoProduct();
        //    }
        //    catch (Exception ex)
        //    {
        //        //throw new BOException("Error while reading Product.", ex);
        //        throw new Exception("ex");
        //    }
        //}
        public List<BO.Product?> ReadAll(Func<BO.Product, bool>? filter = null)
        {
            try
            {

                List<DO.Product> ProductsDO;
                if (filter != null)
                    ProductsDO = _dal.Product.ReadAll(doCust => filter(doCust.ConvertToBoProduct()));
                else
                    ProductsDO = _dal.Product.ReadAll();

                List<BO.Product> ProductsBO = ProductsDO
                    .Select(c => c.ConvertToBoProduct())
                    .ToList();

                return ProductsBO;
            }
            //catch (DalException ex)
            //{
            //    throw new BOException("Error while reading all Products.", ex);
            //}
            catch (Exception ex)
            {

                throw new Exception("ex");
            }
        }

        public void Update(BO.Product Product)
        {
            try
            {
                DO.Product ProductDO = Product.ConvertToDoProduct();
                _dal.Product.Update(ProductDO);
            }
            //catch (DalException ex)
            //{
            //    throw new BOException("Error while updating Product.", ex);
            //}
            catch (Exception ex)
            {
                //throw new BOException("Error while reading Product.", ex);
                throw new Exception("ex");
            }
        }
        public void Delete(int id)
        {
            try
            {
                _dal.Product.Delete(id);
            }
            //catch (DalException ex)
            //{
            //    throw new BOException("Error while deleting Product.", ex);
            //}
            catch (Exception ex)
            {
                //throw new BOException("Error while reading Product.", ex);
                throw new Exception("ex");
            }
        }


        public List<BO.SaleInProduct> GetActiveSales(int productId, bool isCustomer)
        {
            try
            {

                return _dal.Sale.ReadAll(sale => sale.ProdectId == productId && sale.LastTime <= DateTime.Now && sale.EndTime >= DateTime.Now && (isCustomer || !sale.IsForClab))
                     .Select(s => new BO.SaleInProduct(s.UniqueIdAuto, s.AmountForSale, s.PriceForSale, s.IsForClab)).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("jnk");
            }
        }
    }
}
