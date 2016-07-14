namespace ShopCatel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tProduct()
        {
            tPre_orders = new HashSet<tPre_orders>();
            tSold_prod = new HashSet<tSold_prod>();
        }

        [Key]
        public int ID_Product { get; set; }

        public int ID_Supplier { get; set; }

        [Required]
        [StringLength(50)]
        public string Group_of_product { get; set; }

        [Required]
        [StringLength(50)]
        public string Name_of_product { get; set; }

        [Required]
        [StringLength(50)]
        public string Material_of_product { get; set; }

        [Required]
        [StringLength(50)]
        public string Manufacturer_of_product { get; set; }

        public double Price_of_product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tPre_orders> tPre_orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tSold_prod> tSold_prod { get; set; }

        public virtual tSupplier tSupplier { get; set; }
    }
}
