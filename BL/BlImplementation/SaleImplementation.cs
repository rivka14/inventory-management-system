
using System;
using System.Collections.Generic;
using System.Linq;
using static BO.Tools;
using BlApi;

namespace BlImplementation
{
    public class SaleImplementation : ISale
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public int Create(BO.Sale Sale)
        {
            try
            {
                DO.Sale SaleDO = Sale.ConvertToDoSale();
                return _dal.Sale.Creat(SaleDO);

            }
            //catch (DalException ex)
            //{
            //    throw new BOException("Error while creating Sale.", ex);
            //}
            catch (Exception ex)
            {
                throw new Exception("jty");
            }
        }

        public BO.Sale? Read(int id)
        {
            try
            {
                DO.Sale SaleDO = _dal.Sale.Read(id);
                if (SaleDO == null)
                    return null;
                return SaleDO.ConvertToBoSale();
            }
            catch (Exception ex)
            {
                //throw new BOException("Error while reading Sale.", ex);
                throw new Exception("ex");
            }
        }

        public List<BO.Sale?> ReadAll(Func<BO.Sale, bool>? filter = null)
        {
            try
            {

                List<DO.Sale> SalesDO;
                if (filter != null)
                    SalesDO = _dal.Sale.ReadAll(doCust => filter(doCust.ConvertToBoSale()));
                else
                    SalesDO = _dal.Sale.ReadAll();

                List<BO.Sale> SalesBO = SalesDO
                    .Select(c => c.ConvertToBoSale())
                    .ToList();

                return SalesBO;
            }
            //catch (DalException ex)
            //{
            //    throw new BOException("Error while reading all Sales.", ex);
            //}
            catch (Exception ex)
            {

                throw new Exception("ex");
            }
        }

        public void Update(BO.Sale Sale)
        {
            try
            {
                DO.Sale SaleDO = Sale.ConvertToDoSale();
                _dal.Sale.Update(SaleDO);
            }
            //catch (DalException ex)
            //{
            //    throw new BOException("Error while updating Sale.", ex);
            //}
            catch (Exception ex)
            {
                //throw new BOException("Error while reading Sale.", ex);
                throw new Exception("ex");
            }
        }
        public void Delete(int id)
        {
            try
            {
                _dal.Sale.Delete(id);
            }
            //catch (DalException ex)
            //{
            //    throw new BOException("Error while deleting Sale.", ex);
            //}
            catch (Exception ex)
            {
                //throw new BOException("Error while reading Sale.", ex);
                throw new Exception("ex");
            }
        }

    }
}
