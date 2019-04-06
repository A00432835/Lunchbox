namespace LunchBox
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class profile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pId { get; set; }

        public int uid { get; set; }

        [StringLength(50)]
        public string address { get; set; }

        [StringLength(10)]
        public string city { get; set; }

        [StringLength(10)]
        public string province { get; set; }

        [StringLength(10)]
        public string country { get; set; }

        [StringLength(50)]
        public string pic_url { get; set; }

        public virtual user user { get; set; }
    }
}
