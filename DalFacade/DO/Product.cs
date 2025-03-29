namespace DO;
/// <summary>
/// 
/// </summary>
/// <param name="ProductId">מספר מזהה יחודי אוטומטי</param>
/// <param name="ProductName">שם מוצר</param>
/// <param name="CategoryProduct">קטגוריה</param>
/// <param name="Price">מחיר</param>
/// <param name="Amount">כמות במלאי</param>
public record Product
    (int ProductId,
     string? ProductName,
     Category? CategoryProduct,
     int? Price,
     int? Amount
    
    )
    
{
    public Product():this(0," ",Category.Boxes,0,0)
    {
            
    }
}
