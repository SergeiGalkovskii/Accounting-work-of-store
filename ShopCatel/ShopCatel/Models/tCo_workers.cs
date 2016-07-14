namespace ShopCatel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tCo-workers")]
    public partial class tCo_workers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tCo_workers()
        {
            tSold_prod = new HashSet<tSold_prod>();
        }

        [Key]
        [Column("ID_Co-worker")]
        public int ID_Co_worker { get; set; }

        public int ID_Human { get; set; }

        [Required]
        [StringLength(50)]
        public string Position { get; set; }

        [Column(TypeName = "date")]
        public DateTime Employment_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tSold_prod> tSold_prod { get; set; }

        public virtual tPeople tPeople { get; set; }
    }
}
