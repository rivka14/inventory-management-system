using BO;
using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IBl
    {
        ICustomer Customer { get; }
        IProduct Product { get; }
        ISale Sale { get; }
        IOrder Order { get; }
    }
}
