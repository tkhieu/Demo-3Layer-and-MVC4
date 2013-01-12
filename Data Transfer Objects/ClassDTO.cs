using System.Collections.Generic;

namespace Data_Transfer_Objects
{
    public class ClassDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<StudentDTO> Students { get; set; }
    }
}