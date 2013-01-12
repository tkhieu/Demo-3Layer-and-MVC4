using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Presentation.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Class Class { get; set; }
        public double Mark1 { get; set; }
        public double Mark2 { get; set; }
        public double Mark3 { get; set; }
    }
}