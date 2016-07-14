namespace ShopCatel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tPre_orders
    {
        [Key]
        public int ID_Pre_order { get; set; }

        public int ID_Product { get; set; }

        public int ID_Buyer { get; set; }

        public int Count_of_pre_order { get; set; }

        public double Total_price { get; set; }

        public double Paid { get; set; }

        [Column(TypeName = "date")]
        public DateTime Pre_date { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }

        [StringLength(150)]
        public string Note { get; set; }

        public virtual tBuyer tBuyer { get; set; }

        public virtual tProduct tProduct { get; set; }
    }
}
