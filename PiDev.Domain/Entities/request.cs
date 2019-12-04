namespace PiDev.Domain.Entites
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("pidev.request")]
    public partial class request
    {
        public int id { get; set; }
    }
}
