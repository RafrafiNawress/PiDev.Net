namespace PiDev.Domain.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.commentaire")]
    public partial class commentaire
    {
        public int id { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [Column(TypeName = "tinyblob")]
        public byte[] projet { get; set; }

        public int? idEmploye { get; set; }

        public virtual employee employee { get; set; }
    }
}
