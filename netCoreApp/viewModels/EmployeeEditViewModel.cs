using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netCoreApp.viewModels
{
    public class EmployeeEditViewModel : EmployeeCreateViewModel
    {
        public string ExistingPhotoPath { get; set; }
    }
}
