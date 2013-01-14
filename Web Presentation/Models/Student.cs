using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data_Transfer_Objects;

namespace Web_Presentation.Models
{
    public class Student
    {
        public Student(StudentDTO studentDto)
        {
            this.Id = studentDto.Id;
            this.Name = studentDto.Name;
            this.ClassId = studentDto.ClassId;
            this.Class = new Class(studentDto.Class);
            this.Mark1 = studentDto.Mark1;
            this.Mark2 = studentDto.Mark2;
            this.Mark3 = studentDto.Mark3;
        }

        public Student(){}

        public int Id { get; set; }
        public string Name { get; set; }
        public Class Class { get; set; }
        public int ClassId { get; set; }
        public double Mark1 { get; set; }
        public double Mark2 { get; set; }
        public double Mark3 { get; set; }
    }
}