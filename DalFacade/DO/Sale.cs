
using System.Data.Common;

namespace DO;

/// <summary>
/// 
/// </summary>
/// <param name="ProdectId">מזהה מוצר</param>
/// /// <param name="UniqueIdAuto">מספר רץ אוטומטי </param>
/// <param name="AmountForSale">כמות נדרשת למבצע</param>
/// <param name="PriceForSale">מחיר כולל במבצע</param>
/// <param name="IsForClab">מבצע למועדון או לא</param>
/// <param name="LastTime">התחלת המבצע  </param>
/// /// <param name="EndTime">תאריך סוף המבצע</param>
public record Sale
    (
    int ProdectId,
     int AmountForSale,
     int UniqueIdAuto,
     int PriceForSale,
     bool IsForClab,
     DateTime? LastTime,
     DateTime? EndTime
    )
{

    public Sale() : this(0, 3, 0, 0, false, null, null)
    {


    }

}
