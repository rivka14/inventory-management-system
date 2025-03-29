namespace Dal;
using DO;
using DalApi;
using System.Reflection;
using Tools;

internal class ProductImplementation : IProduct
{
    public int Creat(Product item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"insert product in id:{item.ProductId}");
        bool prId = DataSource.products.Any(t => t.ProductId == item.ProductId);
        if (prId)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "This customer exists in this id");
            throw new Dal_exist("The product is already exist", "Product");

        }

        DataSource.products.Add(item);
        Product P = item with { ProductId = DataSource.Confing.ToNextIdProudct };
        return item.ProductId;
    }
    public void Update(Product item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"update Product in id:{item.ProductId}");
        Delete(item.ProductId);
        DataSource.products.Add(item);

    }
    public Product? Read(Func<Product, bool>? filter)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read Product");
        Product? P = DataSource.products.FirstOrDefault(x => filter(x));

        if (P == default)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"not found Product");
            throw new Dal_No_exist("The Product is not exist", "Product");
        }
        return P;
    }
    public Product? Read(int code)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read product in id: {code}");
        Product P;
        P = DataSource.products.FirstOrDefault(t => t.ProductId == code);
        if (P == default)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"not found  product in this id: {code}");

            throw new Dal_No_exist("The Product is not exist", "Product");
        }
        return P;
    }

    public List<Product?> ReadAll(Func<Product, bool>? filter = null)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read all Product");
        if (filter == null)
        {
            List<Product> list = new List<Product>(DataSource.products);
            return list;
        }
        else
        {
            var q = DataSource.products.Where(x => filter(x));
            return q.ToList();
        }
    }

    public void Delete(int id)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"delete product in id:{id}");
        Product product = Read(id);
        DataSource.products.Remove(product);

    }
}
