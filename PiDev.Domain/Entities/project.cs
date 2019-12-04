namespace PiDev.Domain.Entites
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("pidev.project")]
    public partial class project
    {
        public int id { get; set; }
    }
}
