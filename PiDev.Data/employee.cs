namespace PiDev.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.employee")]
    public partial class employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employee()
        {
            commentaire = new HashSet<commentaire>();
            team_employee = new HashSet<team_employee>();
        }

        public int id { get; set; }

        public DateTime? birthday { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string firstname { get; set; }

        [Column(TypeName = "bit")]
        public bool? isActif { get; set; }

        [StringLength(255)]
        public string lastname { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        public int phone { get; set; }

        [StringLength(255)]
        public string photo { get; set; }

        [StringLength(255)]
        public string role { get; set; }

        public int? evaluationsheet_id { get; set; }

        public int? idEvaluationSheet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<commentaire> commentaire { get; set; }

        public virtual evaluationsheet evaluationsheet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<team_employee> team_employee { get; set; }

        public virtual evaluationsheet evaluationsheet1 { get; set; }
    }
}
