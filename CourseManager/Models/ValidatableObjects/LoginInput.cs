using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseManager.Models.ValidatableObjects
{
    public class LoginInput
    {
        [Required]
        [StringLength(20)]
        [Display(Name = "用户名")]
        public string Account {get; set;}

        [Required]
        [StringLength(20)]
        [Display(Name = "用户密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}