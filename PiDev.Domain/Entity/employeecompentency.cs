namespace PiDev.Domain.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("pidev.employeecompentency")]
    public partial class employeecompentency
    {
        public int id { get; set; }
    }
}
