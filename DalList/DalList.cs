using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal sealed class DalList : IDal
    {
        public static DalList Instance { get; private set; } 
        public IProduct Product => new ProductImplementation();
        public ISale Sale => new SaleImplementation();
        public ICustomer Customer => new CustomerImplementation();
        private DalList()
        {
            Instance = new DalList();
        }
    }
}
