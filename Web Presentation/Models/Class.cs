using System.Collections.Generic;

namespace Web_Presentation.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<Student> Students { get; set; }
    }
}