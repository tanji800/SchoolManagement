using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class StudentMetaData
    {
        [StringLength(10)]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [StringLength(10)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name ="Enrollment Date")]
        public Nullable<System.DateTime> EnrollmentDate { get; set; }
        [StringLength (10)]
        [Display(Name ="Middle Name")]
        public string MiddleName { get; set; }
    }
    [MetadataType(typeof(StudentMetaData))]
    public partial class Student1
    {
        
    }
}