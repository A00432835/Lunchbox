namespace LunchBox
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            orders = new HashSet<order>();
            profiles = new HashSet<profile>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int uId { get; set; }

        [StringLength(50)]
        public string UName { get; set; }

        [StringLength(10)]
        public string f_name { get; set; }

        [StringLength(10)]
        public string l_name { get; set; }

        [StringLength(10)]
        public string password { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        public int? u_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<profile> profiles { get; set; }
    }
}
