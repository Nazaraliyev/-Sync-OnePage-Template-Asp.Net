using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sync_OnePage_Template_Asp.Net.ViewModel
{
    public class VmUserRegister
    {

        public IFormFile ImageFile { get; set; }


        [MaxLength(50), Required]
        public string Name { get; set; }



        [MaxLength(50), Required]
        public string Lastname { get; set; }


        [MaxLength(100), Required, EmailAddress]
        public string Email { get; set; }


        [MaxLength(100), Required]
        public string Username { get; set; }


        [MaxLength(15)]
        public string Phone { get; set; }

        
        [MaxLength(100), MinLength(5), DataType(DataType.Password)]
        public string Password { get; set; }



        [MaxLength(100), MinLength(5), DataType(DataType.Password), Compare("Password")]
        public string ConfirmPassword { get; set; }


        [Required]
        public int RoleId { get; set; }




        public List<IdentityRole> Role { get; set; }
    }
}
