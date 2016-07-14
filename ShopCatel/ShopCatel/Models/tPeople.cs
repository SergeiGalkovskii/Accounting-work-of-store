namespace ShopCatel
{
    using Catel.Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tPeople")]
    public partial class tPeople
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tPeople()
        {
            tBuyers = new HashSet<tBuyer>();
            tCo_workers = new HashSet<tCo_workers>();
            tSuppliers = new HashSet<tSupplier>();
        }

        [Key]
        public int ID_Human { get; set; }

        [Required]
        [StringLength(50)]
        public string First_name { get; set; }

        [Required]
        [StringLength(50)]
        public string Second_name { get; set; }

        [Required]
        [StringLength(50)]
        public string Middle_name { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_of_birthday { get; set; }

        [Required]
        [StringLength(50)]
        public string Serias_passport { get; set; }

        public int ID_number { get; set; }

        public short Index_city { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Street { get; set; }

        [StringLength(50)]
        public string Home { get; set; }

        public int Phone_number { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tBuyer> tBuyers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCo_workers> tCo_workers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tSupplier> tSuppliers { get; set; }
    }
}
