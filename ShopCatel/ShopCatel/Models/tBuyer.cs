namespace ShopCatel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tBuyer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tBuyer()
        {
            tSold_prod = new HashSet<tSold_prod>();
            tPre_orders = new HashSet<tPre_orders>();
        }

        [Key]
        public int ID_Buyer { get; set; }

        public int ID_Human { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tSold_prod> tSold_prod { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tPre_orders> tPre_orders { get; set; }

        public virtual tPeople tPeople { get; set; }
    }
}
