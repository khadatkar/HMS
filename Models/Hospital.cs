using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    public class Hospital
    {
        [Key]
        public int HospitalId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public long Mobile { get; set; }
        public string Email { get; set; }
        [Required]
        public string City { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
    }
}
