namespace PiDev.Domain.Entites
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("pidev.evaluationsheet")]
    public partial class evaluationsheet
    {
        public int id { get; set; }
    }
}
