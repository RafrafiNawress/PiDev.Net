namespace PiDev.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("pidev.bill")]
    public partial class bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bill()
        {
            missions = new HashSet<mission>();
        }

        public int id { get; set; }

        public DateTime? date { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        [StringLength(255)]
        public string matricule { get; set; }

        public int? mission_id { get; set; }

        public int? idBill { get; set; }

        public int? idMission { get; set; }

        public int somme { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mission> missions { get; set; }

        public virtual mission mission { get; set; }

        public virtual mission mission1 { get; set; }

        public virtual mission mission2 { get; set; }
    }
}
