using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace CRUD_Operation_withASP.NET.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }


        [Required(ErrorMessage = "Employee Name Is Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Employee Name")]
        public string  Name { get; set; }

        [Required(ErrorMessage = " Salary Is Required")]
        [Display(Name = "Employee Salary")]
        [Range(minimum: 1, maximum: 500000)]
        public double  Salary { get; set; }

    }
}
