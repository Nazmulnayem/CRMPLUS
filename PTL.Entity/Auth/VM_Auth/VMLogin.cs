using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PTL.Entity.Auth.VM_Auth
{
    public class VMLogin
    {
        public List<SelectListItem> listCompanies { get; set; } = new List<SelectListItem>();
        [Required]
        public string SelectedComcod { get; set; }
        [Required]
        public string UserName { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
        public string OldPassword { get; set; } = "";
        public string NewPassword { get; set; } = "";
    }
}
