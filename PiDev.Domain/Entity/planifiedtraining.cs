namespace PiDev.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("pidev.planifiedtraining")]
    public partial class planifiedtraining
    {
        public int id { get; set; }
    }
}
