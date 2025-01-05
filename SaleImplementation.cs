namespace Dal;
using DO;
using DalApi;
internal class SaleImplementation : ISale
{

    public int Creat(Sale item)
    {
        //foreach (Sale? i in DataSource.sales)
        //{
        //    if (i.UniqueIdAuto == item.UniqueIdAuto)
        //        throw new Exception("The Sale is already exist");
        //}
        bool s = DataSource.sales.Any(i => i.UniqueIdAuto == item.UniqueIdAuto);
        if (s)
            throw new Exception("The Sale is already exist");
        else { 
        DataSource.sales.Add(item); Console.WriteLine("sale");
        Sale S = item with { UniqueIdAuto = DataSource.Confing.ToNextIdSale };
        return (int)item.UniqueIdAuto;
           
        }
    }
    public void Update(Sale item)
    {
        Delete(item.UniqueIdAuto);
        DataSource.sales.Add(item);
        Console.WriteLine("the update is successfully");
    }
    public Sale? Read(Func<Sale, bool>? filter)
    {
        //    foreach (Sale i in DataSource.sales)
        //    {
        //        if (i.UniqueIdAuto == id)
        //        {
        //            return i;
        //        }
        //    }
        //    return null;
        Sale? S = DataSource.sales.FirstOrDefault(filter);

        if (S == default)
            throw new Exception("The Sale is not");
        return S;

    }
    public List<Sale> ReadAll(Func<Sale, bool>? filter=null)
    {
        if(filter == null)
           return DataSource.sales.ToList();
        return DataSource.sales.Where(filter).ToList();
    }

    public void Delete(int id)
    {
        Sale s = Read((i) => i.UniqueIdAuto==id);
        if (s != null)
        {
            DataSource.sales.Remove(s);
        }
        else
            throw new Exception("The sale is not exist");

    }
}
