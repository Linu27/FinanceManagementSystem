//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace prjCardDashboardWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CardTypeTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CardTypeTable()
        {
            this.ConsumerTables = new HashSet<ConsumerTable>();
        }
    
        public string CardType { get; set; }
        public Nullable<int> JoiningFee { get; set; }
        public Nullable<int> TotalCredit { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsumerTable> ConsumerTables { get; set; }
    }
}
