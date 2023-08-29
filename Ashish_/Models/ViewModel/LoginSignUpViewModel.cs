using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ashish_.Models.ViewModel
{
    public class LoginSignUpViewModel
    {
        
        int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9]*$")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }


        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Phone number must be 10 digits")]
        public string PhoneNumber { get; set; }

        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Remember Me")]        
        public bool Isremember { get; set; }

        public LoginSignUpViewModel( ) {
            
           
            }
    }
}
