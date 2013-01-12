using System.Collections.Generic;
using System.Linq;
using Data_Access_Layer.Db;
using Data_Transfer_Objects;

namespace Data_Access_Layer.AccessUnit
{
    public class ClassDAL
    {
        private StudentDbEntities _db;

        public List<ClassDTO> GetList()
        {
            _db = new StudentDbEntities();
            var list =  _db.Classes.ToList();
            var listDto = new List<ClassDTO>();
            foreach (var @class in list)
            {
                var classDto = new ClassDTO {Id = @class.Id, Name = @class.Name, Code = @class.Code};
                var listStudentDto = new List<StudentDTO>();
                foreach (var student in @class.Students)
                {
                    var studentDto = new StudentDTO {Id = student.Id, Name = student.Name};
                    var classDal = new ClassDAL();
                    studentDto.Class = classDal.GetById(student.ClassId);
                    if (student.Mark1 != null) studentDto.Mark1 = (double) student.Mark1;
                    if (student.Mark2 != null) studentDto.Mark2 = (double) student.Mark2;
                    if (student.Mark3 != null) studentDto.Mark3 = (double) student.Mark3;
                    listStudentDto.Add(studentDto);
                }
                classDto.Students = listStudentDto;
                listDto.Add(classDto);
            }
            return listDto;
        }

        private ClassDTO GetById(int classId)
        {
            _db = new StudentDbEntities();
            var classDto = new ClassDTO();
            Class c = _db.Classes.First(p => p.Id == classId);
            classDto.Id = c.Id;
            classDto.Name = c.Name;
            classDto.Code = c.Code;
            return classDto;
        }
    }
}
