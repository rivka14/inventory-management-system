

namespace Dal;
using DO;
using DalApi;

internal class ProductImplementation : IProduct
{
    public int Creat(Product item)
    {
        //foreach (Product? i in DataSource.products)
        //{
        //    if (i.ProductId == item.ProductId)
        //        
        //}
        bool prId = DataSource.products.Any(t => t.ProductId == item.ProductId);
        if (prId)
            throw new Exception("The product is already exist");
        DataSource.products.Add(item);
        Product P = item with { ProductId = DataSource.Confing.ToNextIdProudct };
        return item.ProductId;
    }
    public void Update(Product item)
    {
        Delete(item.ProductId);
        DataSource.products.Add(item);
        Console.WriteLine("the update is successfully");
    }
    public Product? Read(Func<Product, bool>? filter)
    {
        //foreach (Product i in DataSource.products)
        //{
        //    if (i.ProductId == id)
        //    {
        //        return i;
        //    }
        //}
        Product? P = DataSource.products.FirstOrDefault(filter);

        if (P == default)
            throw new Exception("The Product is not");
        return P;
    }


    public List<Product?> ReadAll(Func<Product, bool>? filter = null)
    {
        if (filter == null)
            return DataSource.products.ToList();
        return DataSource.products.Where(filter).ToList();
    }

    public void Delete(int id)
    {
        Product p = Read((i) => i.ProductId==id );
        if (p != null)
        {
            DataSource.products.Remove(p);
        }
        else
            throw new Exception("The sale is not exist");

    }
}
