namespace PiDev.Domain.Entites
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("pidev.reclamation")]
    public partial class reclamation
    {
        public int id { get; set; }
    }
}
