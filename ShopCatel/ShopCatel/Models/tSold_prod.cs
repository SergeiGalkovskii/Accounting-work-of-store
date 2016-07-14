namespace ShopCatel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tSold_prod
    {
        [Key]
        public int ID_Sold_prod { get; set; }

        public int ID_Product { get; set; }

        [Column("ID_Co-worker")]
        public int ID_Co_worker { get; set; }

        public int ID_Buyer { get; set; }

        public int Count_of_prod { get; set; }

        public double Total_price { get; set; }

        [Column(TypeName = "date")]
        public DateTime Sold_date { get; set; }

        public virtual tBuyer tBuyer { get; set; }

        public virtual tCo_workers tCo_workers { get; set; }

        public virtual tProduct tProduct { get; set; }
    }
}
