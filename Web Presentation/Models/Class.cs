using System.Collections.Generic;
using Data_Transfer_Objects;

namespace Web_Presentation.Models
{
    public class Class
    {
        public Class(ClassDTO classDto)
        {
            this.Id = classDto.Id;
            this.Name = classDto.Name;
            this.Code = classDto.Code;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}