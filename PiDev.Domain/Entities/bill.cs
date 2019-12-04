namespace PiDev.Domain.Entites
{

    using System.ComponentModel.DataAnnotations.Schema;

    [Table("pidev.bill")]
    public partial class bill
    {
        public int id { get; set; }
    }
}
