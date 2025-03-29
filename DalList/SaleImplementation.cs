namespace Dal;
using DO;
using DalApi;
using Tools;
using System.Reflection;

internal class SaleImplementation : ISale
{

    public int Creat(Sale item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"insert Sale in id:{item.UniqueIdAuto}");
        bool s = DataSource.sales.Any(i => i.UniqueIdAuto == item.UniqueIdAuto);
        if (s)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "This customer exists in this id");
            throw new Dal_exist("The Sale is already exist", "Sale");
        }

        else
        {
            DataSource.sales.Add(item);
            Sale S = item with { UniqueIdAuto = DataSource.Confing.ToNextIdSale };
            return item.UniqueIdAuto;

        }
    }
    public void Update(Sale item)
    {
       
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"update sale in id:{item.UniqueIdAuto}");
        Delete(item.UniqueIdAuto);
        DataSource.sales.Add(item);
    }
    public Sale? Read(Func<Sale, bool>? filter)
    {

        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read sale");
        Sale s = DataSource.sales.FirstOrDefault(x => filter(x));
        if (s == default)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"not found sale");
            throw new Dal_No_exist("this sale not exist","Sale");
        }

        else
            return s;

    }
    public Sale? Read(int code)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read sale int id: {code}");
        Sale? S = DataSource.sales.FirstOrDefault(t => t.UniqueIdAuto == code);
        if (S == default)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"not found  sale in this id: {code}");
            throw new Dal_No_exist("The Sale is not exist", "Sale");
        }
           
        return S;
    }
    public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read all sales");
        if (filter == null)
        {
            List<Sale> list = new List<Sale>(DataSource.sales);
            return list;
        }
        else
        {
            var q = DataSource.sales.Where(x => filter(x));
            return q.ToList();
        }

    }

    public void Delete(int id)
    {
   
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"delete sale in id:{id}");
        Sale sale = Read(id);
        DataSource.sales.Remove(sale);

    }
}
