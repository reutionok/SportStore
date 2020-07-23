using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportStore.WebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Требуется ввести логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Требуется ввести пароль")]
        public string Password { get; set; }
    }
}