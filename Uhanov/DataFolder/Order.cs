//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Uhanov.DataFolder
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int IdOrder { get; set; }
        public int IdPosition { get; set; }
        public string CountExemplar { get; set; }
        public decimal TotalPrice { get; set; }
        public int IdEmployee { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int IdStatusOrder { get; set; }
        public int IdStatusPayment { get; set; }
        public Nullable<System.DateTime> DateOfIssueOrder { get; set; }
        public Nullable<int> IdClient { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual PriceList PriceList { get; set; }
        public virtual StatusOrder StatusOrder { get; set; }
        public virtual StatusPayment StatusPayment { get; set; }
    }
}
