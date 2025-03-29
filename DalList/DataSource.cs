
namespace Dal;
using DO;

static internal class DataSource
{

    static internal List<Customer?> customers = new List<Customer?>();//עד 100
    static internal List<Product?> products = new List<Product?>();//עד 50
    static internal List<Sale?> sales = new List<Sale?>();//עד 20

    static internal class Confing//מספר רץ אוטמטי
    {

        internal const int StartIdSale = 100;
        private static int NextIdSale = StartIdSale;

        internal const int StartIdProudct = 100;
        private static int NextIdProudct = StartIdProudct;
        public static int ToNextIdSale
        {
            get { return NextIdSale++; }

        }
       
        public static int ToNextIdProudct
        {
            get { return NextIdProudct++; }

        }


    }


}



