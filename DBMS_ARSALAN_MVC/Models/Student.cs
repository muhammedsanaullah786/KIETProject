using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DBMS_ARSALAN_MVC.Models
{
    public class Student
    {
        
        [Display(Name = "Student ID")]
        public int sid { get; set; }


        
        [Display(Name = "First Name")]
        public string Fname { get;set; }

        
        [Display(Name = "Last Name")]
        public string Lname { get; set; }

        
        [Display(Name = "Date Of Birth")]
        public string Dob { get; set; }

        
        [Display(Name = "Gender")]
        public bool Gender { get; set; }
        

        [Display(Name = "Semester")]
        public int Semester { get; set; }
        
        [Display(Name = "Addmission Date")]
        public string DOA { get; set; }

        
        [Display(Name = "City")]
        public string City { get; set; }
        
        [Display(Name = "Area")]
        public string Area { get; set; }
        
        [Display(Name = "Street")]
        public string Strt { get; set; }

        
        [Display(Name = "House Number")]
        public string Hno { get; set; }





    }
}