namespace PiDev.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("pidev.mission")]
    public partial class mission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mission()
        {
            bills = new HashSet<bill>();
            bills1 = new HashSet<bill>();
            bills2 = new HashSet<bill>();
            missionrequests = new HashSet<missionrequest>();
            compentencies = new HashSet<compentency>();
            employees = new HashSet<employee>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string DateF { get; set; }

        [StringLength(255)]
        public string dateD { get; set; }

        [StringLength(255)]
        public string location { get; set; }

        public int maxExpense { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        public int valide { get; set; }

        public int? bill_id { get; set; }

        public int? idProject { get; set; }

        public virtual bill bill { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bill> bills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bill> bills1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bill> bills2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<missionrequest> missionrequests { get; set; }

        public virtual project project { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<compentency> compentencies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employee> employees { get; set; }
    }
}
