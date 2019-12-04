namespace PiDev.Domain.Entites
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("pidev.followedup")]
    public partial class followedup
    {
        public int id { get; set; }
    }
}
