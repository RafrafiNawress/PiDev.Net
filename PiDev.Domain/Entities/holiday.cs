namespace PiDev.Domain.Entites
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("pidev.holiday")]
    public partial class holiday
    {
        public int id { get; set; }
    }
}
