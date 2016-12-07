using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BxQuantWeb.Models.ManageViewModels
{
    public class EditUserProfileViewModel
    {
        [Required]
        public string Gender { get; set; }

        [Required]
        public string Location { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
