
using DalApi;
using DO;
using System.ComponentModel.Design;
using System.Reflection;
using System.Runtime.InteropServices;
using Tools;

namespace Dal;
internal class CustomerImplementation : ICustomer
{
    public int Creat(Customer item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"insert customer in id:{item.CustomerTz}");
        bool CusId = DataSource.customers.Any(t => t.CustomerTz == item.CustomerTz);
        if (CusId)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "This customer exists in this id");
            throw new Dal_exist("The coustomer is already exist", "Customer");
        }
        else
            DataSource.customers.Add(item);

        return item.CustomerTz;
    }

    public void Update(Customer item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"update customer in id:{item.CustomerTz}");
        Delete(item.CustomerTz);
        DataSource.customers.Add(item);
    }
    public Customer Read(Func<Customer, bool> filter)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read customer");
        Customer c = DataSource.customers.FirstOrDefault(x => filter(x));

        if (c == default)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"not found customer");
            throw new Dal_No_exist("The Customer is not", "Customer");
        }

        return c;
    }

    public Customer? Read(int code)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read customer in id: {code}");
        Customer customer;
        customer = DataSource.customers.FirstOrDefault(x => x.CustomerTz == code);
        if (customer == null)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"not found  customer in this id: {code}");
            throw new Dal_No_exist("The Customer is not exist", "Customer");
        }

        else
            return customer;
    }
    public List<Customer> ReadAll(Func<Customer, bool>? filter)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read all customers");
        if (filter == null)
        {
            List<Customer> list = new List<Customer>(DataSource.customers);
            return list;
        }
        else
        {
            var q = DataSource.customers.Where(x => filter(x));
            return q.ToList();
        }

    }

    public void Delete(int id)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"delete customer in id:{id}");
        Customer customer = Read(id);
        DataSource.customers.Remove(customer);

    }

}
