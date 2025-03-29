namespace DO;
/// <summary>
/// 
/// </summary>
/// <param name="CustomerTz">ת"ז לקוח</param>
/// <param name="CustomerName">שם לקוח</param>
/// <param name="CustomerAdress">כתובת לקוח</param>
/// <param name="Phone">טלפון</param>
public record Customer
    (int CustomerTz ,
     string? CustomerName,
     string?CustomerAdress,
     string? CustomerPhone 
    )
{



    public Customer() : this(0, "", "", "")//בנאי ריק
    {

    }

}