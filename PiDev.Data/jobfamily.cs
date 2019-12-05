namespace PiDev.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.jobfamily")]
    public partial class jobfamily
    {
        public int id { get; set; }
    }
}
