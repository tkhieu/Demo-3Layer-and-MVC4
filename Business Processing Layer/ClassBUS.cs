using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.AccessUnit;
using Data_Transfer_Objects;

namespace Business_Processing_Layer
{
    public class ClassBUS
    {
        private ClassDAL _classDal;

        public List<Data_Transfer_Objects.ClassDTO> GetList()
        {
            _classDal = new ClassDAL();
            List<ClassDTO> list = _classDal.GetList();
            return list;
        }

        public Data_Transfer_Objects.ClassDTO GetById(int id)
        {
            _classDal = new ClassDAL();
            ClassDTO classDto = _classDal.GetById(id);
            return classDto;
        }

        public void Save(Data_Transfer_Objects.ClassDTO classDto)
        {
            _classDal = new ClassDAL();
            _classDal.Save(classDto);
        }

        public void Update(ClassDTO classDto)
        {
            _classDal = new ClassDAL();
            _classDal.Update(classDto);
        }

        public void Delete(int id)
        {
            _classDal = new ClassDAL();
            _classDal.Delete(id);
        }
    }
}
