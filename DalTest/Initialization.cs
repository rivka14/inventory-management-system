
namespace DalTest;
using DalApi;
using DO;

using System.Data.Common;


public static class Initialization
{

    private static IDal s_dal;

    private static void CreateProudct()
    {
        
        Product p1 = new Product(3,"jj",0,0,0);
        Product p2 = new Product(2, "jj", 0, 0, 0);
       s_dal.Product.Creat(p1);
        s_dal.Product.Creat(p2);
       

    }

    private static void CreateSale()
    {
       
       Sale sale = new Sale();
        Sale S1 = new Sale(1,5,4, 1,true, new DateTime(2024, 12, 05), new DateTime(2024,10,05));
       Sale S2 = new Sale(2, 5, 5, 1, false, null, null);
        Sale S3 = new Sale(3, 5, 6, 1, false, null, null);
        Sale S4 = new Sale(4, 5, 7, 1, false, null, null);
       

        s_dal.Sale.Creat(sale);
        s_dal.Sale.Creat(S1);
        s_dal.Sale.Creat(S2);
        s_dal.Sale.Creat(S3);
        s_dal.Sale.Creat(S4);
    }

    private static void CreateCustomer()
    {
        Customer C1 = new Customer(02745112,"Lea", "Jerusalem ","089745541");
        Customer C2 = new Customer(123456,"Shira","Modin_Hilit","052874541");
        Customer C3 = new Customer(789564, "Rachel", "Ashdod ", "047587665");
        s_dal.Customer.Creat(C1);
        s_dal.Customer.Creat(C2);
        s_dal.Customer.Creat(C3);

     
    }
    public static void Initialize() 
    {
       
        s_dal = DalApi.Factory.Get;
        CreateProudct();
        CreateSale();
        CreateCustomer();
        
    }
}
