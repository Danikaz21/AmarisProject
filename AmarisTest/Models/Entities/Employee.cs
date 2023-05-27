using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmarisTest.Models.Entities
{
    public class Employee
    {
        public string id { get; set; }
        public string employee_name { get; set; }
        public int employee_salary { get; set; }
        public string employee_age { get; set; }
        public string profile_image { get; set; }

    }
}