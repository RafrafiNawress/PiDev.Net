namespace PiDev.web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.team_employee")]
    public partial class team_employee
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Teams_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Employees_id { get; set; }

        public int Team_id { get; set; }

        public virtual employee employee { get; set; }

        public virtual team team { get; set; }

        public virtual team team1 { get; set; }
    }
}
