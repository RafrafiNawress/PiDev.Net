namespace PiDev.Domain.Entites
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("pidev.planifiedtraining")]
    public partial class planifiedtraining
    {
        public int id { get; set; }
    }
}
