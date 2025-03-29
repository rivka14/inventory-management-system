using DalApi;

using DO;
using System.Data.Common;

namespace DalTest;

internal class Program
{
    private static IDal s_dal = DalApi.Factory.Get;


    private static void Main(string[] args)
    {
        Initialization.Initialize();

        try
        {
            //אתחול הרשימות
            int select = PrintMainMenu();//הדפסת התפריט הראשי
            while (select != 0)
            {
                switch (select)
                {
                    case 1:
                        ProductSubMenu();
                        break;

                    case 2:
                        CustomerSubMenu();
                        break;
                    case 3:
                        SaleSubMenu();
                        break;
                    default:
                        Console.WriteLine("בחירה שגויה");
                        break;
                }
                select = PrintMainMenu();
            }
            if (select == 0)
            {
                Console.WriteLine("The program is finshed");
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    public static int PrintMainMenu()
    {
        int select;
        Console.WriteLine("For exit type 0");
        Console.WriteLine("For product type 1");
        Console.WriteLine("For customer type 2");
        Console.WriteLine("For sale type 3");
        if (!int.TryParse(Console.ReadLine(), out select))

            select = -1;
        return select;
    }
    public static int PrintSubMenu(string item)
    {
        Console.WriteLine($"You are in {item}");

        Console.WriteLine("For backing to main menu type 0");
        Console.WriteLine($"For create new {item} type 1");
        Console.WriteLine($"For read 1 item from {item} type 2");
        Console.WriteLine($"For readAll from {item} type 3");
        Console.WriteLine($"For update {item} type 4");
        Console.WriteLine($"For delete {item} type 5");
        int select;
        if (!int.TryParse(Console.ReadLine(), out select))
            select = -1;
        return select;
    }

    public static void ProductSubMenu()
    {
        int select = PrintSubMenu("Product");
        while (select != 0)
        {
            switch (select)
            {
                case 1:
                    CreateProduct();
                    break;
                case 2:
                    Read<Product>(s_dal.Product);
                    break;
                case 3:
                    Func<Product, bool> f = (i) => i.Price <100;
                    s_dal.Product.ReadAll(f);
                 
                    break;
                case 4:
                    UpdateProduct();
                    break;
                case 5:
                    Delete<Product>(s_dal.Product);
                    break;
                default:
                    Console.WriteLine("בחירה שגויה");
                    break;
            }
            select = PrintSubMenu("Product");
        }

    }
    public static void SaleSubMenu()
    {
        int select = PrintSubMenu("Sale");
        while (select != 0)
        {
            switch (select)
            {
                case 1:
                    CreateSale();
                    break;
                case 2:
                    Read<Sale>(s_dal.Sale);
                    break;
                case 3:
                    Func<Sale, bool> f = (i) => !i.IsForClab;
                    s_dal.Sale.ReadAll(f);
                    ReadAll<Sale>(s_dal.Sale);
                    break;
                case 4:
                    UpdateSale();
                    break;
                case 5:
                    Delete<Sale>(s_dal.Sale);
                    break;
                default:
                    Console.WriteLine("בחירה שגויה");
                    break;
            }
            select = PrintSubMenu("Sale");
        }

    }
    public static void CustomerSubMenu()
    {
        int select = PrintSubMenu("Customer");

        while (select != 0)
        {
            switch (select)
            {
                case 1:
                    CreateCustomer();
                    break;
                case 2:
                    Read<Customer>(s_dal.Customer);
                    break;
                case 3:
                    Func<Customer, bool> f = (i) => i.CustomerName.Length > 2;//תנאי
                    var c = s_dal.Customer.ReadAll(f);
                    foreach (Customer v in c)
                        Console.WriteLine(v);
                    break;
                case 4:
                    UpdateCustomer();
                    break;
                case 5:
                    Delete<Customer>(s_dal.Customer);
                    break;
                default:
                    Console.WriteLine("בחירה שגויה");
                    break;
            }
            select = PrintSubMenu("Customer");
        }

    }

    private static void UpdateProduct()
    {
        try
        {

            int id = int.Parse(Console.ReadLine());
            Product p = AskProduct(id);

            s_dal.Product.Update(p);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void CreateProduct()
    {
        try
        {
            Product p = AskProduct();
            s_dal.Product.Creat(p);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static Product AskProduct(int id = 0)
    {

        Console.WriteLine("Enter ProductId, ProductName, CategoryProduct, Price, Amount");
        int ProductId = int.Parse(Console.ReadLine());
        string ProductName = Console.ReadLine();

        int cat = int.Parse(Console.ReadLine());
        Category CategoryProduct = (Category)cat;
        Console.WriteLine(string.Join(' ', Enum.GetValues(typeof(Category))));
        int Price = int.Parse(Console.ReadLine());
        int Amount = int.Parse(Console.ReadLine());

        return new Product(ProductId, ProductName, CategoryProduct, Price, Amount);
    }

    private static void UpdateSale()
    {
        try
        {
            int id = int.Parse(Console.ReadLine());
            //Sale s = AskSale(id);
            Sale s1 = AskSale(id);
            s_dal.Sale.Update(s1);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void CreateSale()
    {
        try
        {
            Sale s = AskSale();
            s_dal.Sale.Creat(s);
        }
        catch (Exception ex)
        {
            Console.WriteLine("oppss");
            Console.WriteLine(ex.Message);

        }
    }

    private static Sale AskSale(int ProdectId = 0)
    {
        Console.WriteLine("Enter ProdectId,AmountForSale, UniqueIdAuto,PriceForSale , IsForClab, LastTime, EndTime ");
        ProdectId = int.Parse(Console.ReadLine());
        int AmountForSale = int.Parse(Console.ReadLine());
        int UniqueIdAuto = int.Parse(Console.ReadLine());
        int PriceForSale = int.Parse(Console.ReadLine());
        bool IsForClab = bool.Parse(Console.ReadLine());


        int day1 = int.Parse(Console.ReadLine());
        int mounth1 = int.Parse(Console.ReadLine());
        int year1 = int.Parse(Console.ReadLine());

        int day2 = int.Parse(Console.ReadLine());
        int mounth2 = int.Parse(Console.ReadLine());
        int year2 = int.Parse(Console.ReadLine());
        DateTime LastTime = new DateTime(year1, mounth1, day1);
        DateTime EndtTime = new DateTime(year2, mounth2, day2);

        return new Sale(ProdectId, AmountForSale, UniqueIdAuto, PriceForSale, IsForClab, LastTime, EndtTime);
    }
    private static void UpdateCustomer()
    {
        try
        {
            
            Console.WriteLine("insert id");
            int id = int.Parse(Console.ReadLine());
            Customer c = AskCustomer(id);

            s_dal.Customer.Update(c);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void CreateCustomer()
    {
        try
        {
            Customer c = AskCustomer();
            s_dal.Customer.Creat(c);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static Customer AskCustomer(int id = 0)
    {
        if (id == 0)
        {
            Console.WriteLine("Enter CustomerTz ,CustomerName,CustomerAdress, CustomerPhone ");
            int CustomerTz = int.Parse(Console.ReadLine());
            string CustomerName = Console.ReadLine();
            string CustomerAdress = Console.ReadLine();
            string CustomerPhone = Console.ReadLine();
            return new Customer(CustomerTz, CustomerName, CustomerAdress, CustomerPhone);

        }
        else
        {
            Console.WriteLine("Enter CustomerName,CustomerAdress, CustomerPhone ");
            int CustomerTz = id;
            string CustomerName = Console.ReadLine();
            string CustomerAdress = Console.ReadLine();
            string CustomerPhone = Console.ReadLine();
            return new Customer(CustomerTz, CustomerName, CustomerAdress, CustomerPhone);
        }

    }
        
    private static void Read<T>(ICrud<T> crud)
    {
        try
        { 
            Console.WriteLine("Enter the id for reading");
            int code = int.Parse(Console.ReadLine());
           
           Func<T, bool> func= (item) => item.Equals(code);
           
            Console.WriteLine(crud.Read(code));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void ReadAll<T>(ICrud<T> crud)
    {
        
        Console.WriteLine(string.Join('\n', crud.ReadAll()));


    }

    private static void Delete<T>(ICrud<T> crud)
    {
        try
        {
            Console.WriteLine("Enter the id for delete the item");
            int code = int.Parse(Console.ReadLine());
            crud.Delete(code);
        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
        }

    }
}


