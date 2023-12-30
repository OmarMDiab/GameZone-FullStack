using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Gamezone.Models
{
    [MetadataType(typeof(LoginViewModel))]
    public partial class User
    {
        
    }



    public class LoginViewModel
    {
        [Required]
        public string user_name { get; set; }

        [Required]
        public string user_password { get; set; }
       
    }


}