using System;
using System.Collections.Generic;
using System.Linq;
using static BO.Tools;
using BlApi;

namespace BlImplementation
{
    public class CustomerImplementation : ICustomer
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public int Create(BO.Customer customer)
        {
            try
            {
                DO.Customer customerDO = customer.ConvertToDoCustomer();
                return _dal.Customer.Creat(customerDO);

            }
            catch (Exception ex)
            {
                throw new Exception("jty");
            }
        }

        public BO.Customer? Read(int id)
        {
            try
            {
                DO.Customer customerDO = _dal.Customer.Read(id);
                if (customerDO == null)
                    return null;
                return customerDO.ConvertToBoCustomer();
            }
            catch (Exception ex)
            {
                throw new Exception("ex");
            }
        }

        public List<BO.Customer?> ReadAll(Func<BO.Customer, bool>? filter = null)
        {
            try
            {

                List<DO.Customer> customersDO;
                if (filter != null)
                    customersDO = _dal.Customer.ReadAll(doCust => filter(doCust.ConvertToBoCustomer()));
                else
                    customersDO = _dal.Customer.ReadAll();

                List<BO.Customer> customersBO = customersDO
                    .Select(c => c.ConvertToBoCustomer())
                    .ToList();

                return customersBO;
            }
            catch (Exception ex)
            {

                throw new Exception("ex");
            }
        }

        public void Update(BO.Customer customer)
        {
            try
            {
                DO.Customer customerDO = customer.ConvertToDoCustomer();
                _dal.Customer.Update(customerDO);
            }
            catch (Exception ex)
            {
                throw new Exception("ex");
            }
        }
        public void Delete(int id)
        {
            try
            {
                _dal.Customer.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("ex");
            }
        }
        public bool IsCustomerExists(int id)
        {
            try
            {
                
                _dal.Customer.Read(id);
                return true;
            }
            catch (Exception ex)
            {
                return  false;                        
            }
        }
    }
}
