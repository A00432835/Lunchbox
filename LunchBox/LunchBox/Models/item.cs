namespace LunchBox
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public item()
        {
            orderDetails = new HashSet<orderDetail>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int itemId { get; set; }

        [StringLength(10)]
        public string snackType { get; set; }

        [StringLength(10)]
        public string snackState { get; set; }

        public double? basePrice { get; set; }

        public int? quantity { get; set; }

        public int? unit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderDetail> orderDetails { get; set; }
    }
}
