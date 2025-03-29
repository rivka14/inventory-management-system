using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface ISale
    {
        int Create(BO.Sale sale);
        BO.Sale? Read(int id);
        List<BO.Sale?> ReadAll(Func<BO.Sale, bool>? filter = null);
        void Update(BO.Sale sale);
        void Delete(int id);
    }
}

