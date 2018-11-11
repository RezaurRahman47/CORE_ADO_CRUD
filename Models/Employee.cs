using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_ADO_CRUD.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="OOPS..!! You forgot to give the name.")]
        public string Name { get; set; }
        [Required (ErrorMessage ="Employee must have Gender.")]
        public string Gender { get; set; }
        [Required (ErrorMessage ="Please provide Employee department.")]
        public string Department { get; set; }
        [Required (ErrorMessage ="Please provide the city.")]
        public string City { get; set; }


    }
}
