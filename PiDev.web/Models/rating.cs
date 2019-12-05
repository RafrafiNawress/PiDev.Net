namespace PiDev.web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.rating")]
    public partial class rating
    {
        public int id { get; set; }

        [StringLength(255)]
        public string comment { get; set; }

        public DateTime? created_at { get; set; }

        public int rate { get; set; }

        public int? employee_id { get; set; }
    }
}
