using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ashish_.Models.Account;

namespace Ashish_.Models
{
    public class Vehicle
    {

        [Key]
        public int VehicleID { get; set; }

        [ForeignKey("User")]
        public int userId { get; set; }
        public virtual User User { get; set; } 

        public string Brand { get; set; }

        public string Model { get; set; }


        public int Year { get; set; }

        [RegularExpression("^[a-zA-Z0-9]$")]
        public string LPN { get; set; }

        public string Fule { get; set; }

        public Vehicle( int VehicleID, int userId,string Brand,string Model,int Year,string LPN,string Fule)
        {
            this.VehicleID = VehicleID; 
            this.userId = userId;
            this.Brand = Brand;
            this.Model = Model;
            this.Year = Year;
            this.LPN = LPN;
            this.Fule = Fule;

        }

    }
}
