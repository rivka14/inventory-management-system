using DO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public static class Tools
    {
        public static BO.Customer ConvertToBoCustomer(this DO.Customer c)
        {

            return new BO.Customer(c.CustomerTz, c.CustomerName, c.CustomerAdress, c.CustomerPhone);
        }
        public static DO.Customer ConvertToDoCustomer(this BO.Customer c)
        {

            return new DO.Customer(c.CustomerTz, c.CustomerName, c.CustomerAddress, c.CustomerPhone);
        }
        public static BO.Sale ConvertToBoSale(this DO.Sale s)
        {

            return new BO.Sale(s.ProdectId, s.AmountForSale, s.UniqueIdAuto, s.PriceForSale, s.IsForClab, s.LastTime, s.EndTime);
        }
        public static DO.Sale ConvertToDoSale(this BO.Sale s)
        {

            return new DO.Sale(s.ProductId, s.AmountForSale, s.UniqueIdAuto, s.PriceForSale, s.IsForClab, s.LastTime, s.EndTime);
        }
        public static BO.Product ConvertToBoProduct(this DO.Product p)
        {
           

            return new BO.Product(p.ProductId, p.ProductName,(BO.Category)p.CategoryProduct, p.Price, p.Amount );
        }
        public static DO.Product ConvertToDoProduct(this BO.Product p)
        {
           
            return new DO.Product(p.ProductId, p.ProductName, (DO.Category)p.CategoryProduct, p.Price, p.Amount);


        }
        public static string ToStringProperty<T>(this T obj)
        {
            var result = "";
            var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var value = property.GetValue(obj);
                if (value is IEnumerable<object> list && !(value is string))  // אם זה אוסף
                {
                    result += $"{property.Name}: [{string.Join(", ", list.Select(x => x.ToString()))}]\n";
                }
                else
                {
                    result += $"{property.Name}: {value}\n";
                }
            }

            return result;
        }
    }
}