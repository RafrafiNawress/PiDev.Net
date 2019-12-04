namespace PiDev.Domain.Entites
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("pidev.commentaire")]
    public partial class commentaire
    {
        public int id { get; set; }
    }
}
