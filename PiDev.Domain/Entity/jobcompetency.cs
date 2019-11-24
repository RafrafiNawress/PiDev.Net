namespace PiDev.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("pidev.jobcompetency")]
    public partial class jobcompetency
    {
        public int id { get; set; }
    }
}
