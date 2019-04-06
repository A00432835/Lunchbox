namespace LunchBox
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class orderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int orderDetail_ID { get; set; }

        public int? orderID { get; set; }

        public int? itemID { get; set; }

        public int? quantity { get; set; }

        public virtual item item { get; set; }

        public virtual order order { get; set; }
    }
}
