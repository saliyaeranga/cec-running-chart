using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CECRunningChart.Web.Models.User
{
    public class LogOnModel
    {
        [DisplayName("User Name")]
        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(20, ErrorMessage = "First name can not have more than 20 characters")]
        public string UserName { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(20, ErrorMessage = "Password can not have more than 20 characters")]
        public string Password { get; set; }
    }
}