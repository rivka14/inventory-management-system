using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Customer
    {
        public int CustomerTz { get; init; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public Customer(int CustomerTz, string CustomerName, string CustomerAdress, string CustomerPhone)
        {
            this.CustomerTz = CustomerTz;
            this.CustomerName = CustomerName;
           this.CustomerAddress = CustomerAdress;
            this.CustomerPhone = CustomerPhone;

        }
     
    }

}
