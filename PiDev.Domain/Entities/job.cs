namespace PiDev.Domain.Entites
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("pidev.job")]
    public partial class job
    {
        public int id { get; set; }
    }
}
