namespace LunchBox
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class payment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int paymentID { get; set; }

        [StringLength(50)]
        public string nameOnCard { get; set; }

        [StringLength(50)]
        public string cardType { get; set; }

        public long? cardNumber { get; set; }

        public int? orderID { get; set; }

        [StringLength(50)]
        public string expiryDate { get; set; }

        public int? cvv { get; set; }

        public int? discountID { get; set; }

        public double? totalPrice { get; set; }

        public virtual discount discount { get; set; }

        public virtual order order { get; set; }
    }
}
