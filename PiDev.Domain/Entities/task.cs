namespace PiDev.Domain.Entites
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("pidev.task")]
    public partial class task
    {
        public int id { get; set; }
    }
}
