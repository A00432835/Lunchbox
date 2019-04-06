namespace LunchBox
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("scheduleType")]
    public partial class scheduleType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int scheduleID { get; set; }

        [Column("scheduleType")]
        [StringLength(50)]
        public string scheduleType1 { get; set; }
    }
}
