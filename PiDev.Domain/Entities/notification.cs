namespace PiDev.Domain.Entites
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("pidev.notification")]
    public partial class notification
    {
        public int id { get; set; }
    }
}
