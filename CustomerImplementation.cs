using DO;
using DalApi;
using System.Linq;
namespace Dal;

internal class CustomerImplementation : ICustomer
{
    public int Creat(Customer item)
    {
        bool CusId = DataSource.customers.Any(t => t.CustomerTz == item.CustomerTz);
        if (CusId)
            throw new Exception("The coustomer is already exist");
        DataSource.customers.Add(item);
        return (int)item.CustomerTz;
    }
    public void Update(Customer item)
    {
        Delete(item.CustomerTz);
        DataSource.customers.Add(item);
        Console.WriteLine("the update is successfully");
    }
    public Customer Read(Func<Customer, bool>? filter)
    {


        Customer? C = DataSource.customers.FirstOrDefault(filter);
        
        if (C == default)
            throw new Exception("The Customer is not");
         return C;
    }
    public List<Customer> ReadAll(Func<Customer, bool>? filter)
    {

        if (filter == null)
            return DataSource.customers.ToList();

        return DataSource.customers.Where(filter).ToList();

    }

    public void Delete(int id)
    {
        Customer c = Read((i) => i.CustomerTz == id);
        if (c != null)
        {
            DataSource.customers.Remove(c);
        }
        else
            throw new Exception("The coustomer is not exist");

    }
}
