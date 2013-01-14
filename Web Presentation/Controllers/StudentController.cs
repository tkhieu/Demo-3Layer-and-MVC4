using System.Linq;
using System.Web.Mvc;
using Business_Processing_Layer;
using Data_Transfer_Objects;
using Web_Presentation.Models;

namespace Web_Presentation.Controllers
{
    public class StudentController : Controller
    {
        private readonly Context _db = new Context();
        private readonly StudentBUS _studentBus = new StudentBUS();

        //
        // GET: /Student/

        public ActionResult Index()
        {
            var listStudentDtos = _studentBus.GetList();
            var students = listStudentDtos.Select(studentDto => new Student(studentDto)).ToList();
            return View(students);
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id = 0)
        {
            StudentDTO studentDto = _studentBus.GetById(id);
            var s = new Student(studentDto);
            if (studentDto == null)
            {
                return HttpNotFound();
            }
            return View(s);
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Student/Create

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                var studentDto = new StudentDTO
                                     {
                                         Name = student.Name,
                                         ClassId = student.ClassId,
                                         Mark1 = student.Mark1,
                                         Mark2 = student.Mark2,
                                         Mark3 = student.Mark3
                                     };
                _studentBus.Save(studentDto);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(int id = 0)
        {
            StudentDTO studentDto = _studentBus.GetById(id);
            var student = new Student(studentDto);
            return View(student);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                var studentDto = new StudentDTO
                                     {
                                         Id = student.Id,
                                         Name = student.Name,
                                         ClassId = student.ClassId,
                                         Mark1 = student.Mark1,
                                         Mark2 = student.Mark2,
                                         Mark3 = student.Mark3
                                     };
                _studentBus.Update(studentDto);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(int id = 0)
        {
            StudentDTO studentDto = _studentBus.GetById(id);
            var student = new Student(studentDto);
            return View(student);
        }

        //
        // POST: /Student/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _studentBus.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}