using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Data_Transfer_Objects;
using Web_Presentation.Models;
using Business_Processing_Layer;

namespace Web_Presentation.Controllers
{
    public class ClassController : Controller
    {
        readonly ClassBUS _classBus = new ClassBUS();

        //
        // GET: /Class/

        public ActionResult Index()
        {
            List<ClassDTO> listClassDTO = _classBus.GetList();
            var classes = listClassDTO.Select(classDto => new Class(classDto)).ToList();
            return View(classes);
        }

        //
        // GET: /Class/Details/5

        public ActionResult Details(int id = 0)
        {
            ClassDTO classDto = _classBus.GetById(id);
            var c = new Class(classDto);
            if (classDto == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }

        //
        // GET: /Class/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Class/Create

        [HttpPost]
        public ActionResult Create(Class c)
        {
            if (ModelState.IsValid)
            {
                var classDto = new ClassDTO {Name = c.Name, Code = c.Code};
                _classBus.Save(classDto);
                return RedirectToAction("Index");
            }

            return View(c);
        }

        //
        // GET: /Class/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ClassDTO classDto = _classBus.GetById(id);
            var c = new Class(classDto);
            return View(c);
        }

        //
        // POST: /Class/Edit/5

        [HttpPost]
        public ActionResult Edit(Class c)
        {
            if (ModelState.IsValid)
            {

                var classDto = new ClassDTO {Id = c.Id, Name = c.Name, Code = c.Code};
                _classBus.Update(classDto);
                return RedirectToAction("Index");
            }
            return View(c);
        }

        //
        // GET: /Class/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ClassDTO classDto = _classBus.GetById(id);
            var c = new Class(classDto);
            return View(c);
        }

        //
        // POST: /Class/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _classBus.Delete(id);
            return RedirectToAction("Index");
        }
    }
}