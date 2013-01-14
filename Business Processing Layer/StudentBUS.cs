using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.AccessUnit;
using Data_Transfer_Objects;

namespace Business_Processing_Layer
{
    public class StudentBUS
    {
        private StudentDAL _studentDal;

        public List<StudentDTO> GetList()
        {
            _studentDal = new StudentDAL();
            List<StudentDTO> list = _studentDal.GetList();
            return list;
        }

        public StudentDTO GetById(int id)
        {
            _studentDal = new StudentDAL();
            return _studentDal.GetById(id);

        }

        public void Save(StudentDTO studentDto)
        {
            _studentDal = new StudentDAL();
            _studentDal.Save(studentDto);
        }

        public void Update(StudentDTO studentDto)
        {
            _studentDal = new StudentDAL();
            _studentDal.Update(studentDto);
        }

        public void Delete(int id)
        {
            _studentDal = new StudentDAL();
            _studentDal.Delete(id);
        }
    }
}
