namespace PiDev.Domain.Entites
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("pidev.missionrequest")]
    public partial class missionrequest
    {
        public int id { get; set; }
    }
}
