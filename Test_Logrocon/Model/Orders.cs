//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test_Logrocon.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        public int Number { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
    
        public virtual Customers Customers { get; set; }
    }
}
