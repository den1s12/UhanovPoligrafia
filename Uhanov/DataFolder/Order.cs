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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.Client = new HashSet<Client>();
        }
    
        public int IdOrder { get; set; }
        public int IdPosition { get; set; }
        public int CountExemplar { get; set; }
        public decimal TotalPrice { get; set; }
        public int IdEmployee { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int IdStatusOrder { get; set; }
        public int IdStatusPayment { get; set; }
        public Nullable<System.DateTime> DateOfIssueOrder { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Client> Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual PriceList PriceList { get; set; }
        public virtual StatusOrder StatusOrder { get; set; }
        public virtual StatusPayment StatusPayment { get; set; }
    }
}
