using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Db;
using Data_Transfer_Objects;

namespace Data_Access_Layer.AccessUnit
{
    public class StudentDAL
    {
        private StudentDbEntities _db;

        public List<StudentDTO> GetList()
        {
            _db = new StudentDbEntities();
            var list = _db.Students.ToList();
            var listDto = new List<StudentDTO>();
            foreach (var student in list)
            {
                StudentDTO studentDto = new StudentDTO();
                studentDto.Id = student.Id;
                studentDto.Name = student.Name;
                studentDto.ClassId = student.ClassId;
                if (student.Mark1 != null) studentDto.Mark1 = (double) student.Mark1;
                if (student.Mark2 != null) studentDto.Mark2 = (double) student.Mark2;
                if (student.Mark3 != null) studentDto.Mark3 = (double) student.Mark3;
                studentDto.Class = new ClassDAL().GetById(student.ClassId);
                studentDto.ClassId = student.ClassId;
                listDto.Add(studentDto);
            
            }
            return listDto;
        }

        public StudentDTO GetById(int studentId)
        {
            _db = new StudentDbEntities();
            var studentDto = new StudentDTO();
            Student student = _db.Students.First(p => p.Id == studentId);
            studentDto.Id = student.Id;
            studentDto.Name = student.Name;
            studentDto.ClassId = student.ClassId;
            studentDto.Class = new ClassDAL().GetById(student.ClassId);
            if (student.Mark1 != null) studentDto.Mark1 = (double) student.Mark1;
            if (student.Mark2 != null) studentDto.Mark2 = (double) student.Mark2;
            if (student.Mark3 != null) studentDto.Mark3 = (double) student.Mark3;
            return studentDto;
        }

        public void Save(StudentDTO studentDto)
        {
            _db = new StudentDbEntities();
            var student = new Student {Id = GetMaxId()};
            student.Name = studentDto.Name;
            student.ClassId = studentDto.ClassId;
            student.Mark1 = (decimal?) studentDto.Mark1;
            student.Mark2 = (decimal?) studentDto.Mark2;
            student.Mark3 = (decimal?) studentDto.Mark3;
            _db.Students.Add(student);
            _db.SaveChanges();
        }

        private int GetMaxId()
        {
            try
            {
                _db = new StudentDbEntities();
                return _db.Students.Max(p => p.Id) + 1;
            }
            catch (Exception)
            {
                return 1;
            }
        }

        public void Update(StudentDTO studentDto)
        {
            _db = new StudentDbEntities();
            Student student = _db.Students.First(p => p.Id == studentDto.Id);
            studentDto.Name = student.Name;
            studentDto.ClassId = student.ClassId;
            if (student.Mark1 != null) studentDto.Mark1 = (double) student.Mark1;
            if (student.Mark2 != null) studentDto.Mark2 = (double) student.Mark2;
            if (student.Mark3 != null) studentDto.Mark3 = (double) student.Mark3;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db = new StudentDbEntities();
            Student student = _db.Students.First(p => p.Id == id);
            _db.Students.Remove(student);
            _db.SaveChanges();
        }
    }
}
