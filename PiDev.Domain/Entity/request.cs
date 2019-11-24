namespace PiDev.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("pidev.request")]
    public partial class request
    {
        public int id { get; set; }
    }
}
