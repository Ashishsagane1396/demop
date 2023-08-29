using System.ComponentModel.DataAnnotations;

namespace Ashish_.Models.Account
{
    public class User
    {
        [Key]
      public   int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9]*$")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }


        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Phone number must be 10 digits")]
        public string PhoneNumber { get; set; }

        public string Password { get; set; }
         
       


        public User( )
        { }

     
    }
}
