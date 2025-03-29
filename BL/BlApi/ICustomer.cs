using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface ICustomer
    {
            int Create(BO.Customer Customer);
            BO.Customer? Read(int id);
            List<BO.Customer?> ReadAll(Func<BO.Customer, bool>? filter = null);
            void Update(BO.Customer Customer);
            void Delete(int id);
            bool IsCustomerExists(int id); 
        
    }

}

