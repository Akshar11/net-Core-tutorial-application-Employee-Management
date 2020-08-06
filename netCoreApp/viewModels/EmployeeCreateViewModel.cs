using Microsoft.AspNetCore.Http;
using netCoreApp.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netCoreApp.viewModels
{
    public class EmployeeCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Max length is 50")]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Dept? Department { get; set; }
        public IFormFile Photo { get; set; }
    }
}
