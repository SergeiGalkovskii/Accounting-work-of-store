namespace ShopCatel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tSupplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tSupplier()
        {
            tProducts = new HashSet<tProduct>();
        }

        [Key]
        public int ID_Supplier { get; set; }

        public int ID_Human { get; set; }

        [Required]
        [StringLength(50)]
        public string Company { get; set; }

        public virtual tPeople tPeople { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tProduct> tProducts { get; set; }
    }
}
