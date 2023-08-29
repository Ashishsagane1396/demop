using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ashish_.Models
{
    public class MaintenanceRecords
    {
        [Key]
        public int RecordID { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.Now;

        public string Description { get; set; }
        public int Cost { get; set; }




        public MaintenanceRecords()
        {


        }



    }
}
