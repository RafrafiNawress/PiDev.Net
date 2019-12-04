namespace PiDev.Domain.Entites
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("pidev.mission")]
    public partial class mission
    {
        public int id { get; set; }
    }
}
