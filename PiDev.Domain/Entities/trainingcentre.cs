namespace PiDev.Domain.Entites
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("pidev.trainingcentre")]
    public partial class trainingcentre
    {
        public int id { get; set; }
    }
}
