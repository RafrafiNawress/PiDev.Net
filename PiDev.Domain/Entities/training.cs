namespace PiDev.Domain.Entites
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("pidev.training")]
    public partial class training
    {
        public int id { get; set; }
    }
}
