using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data_Transfer_Objects;
using Web_Presentation.Models;
using Business_Processing_Layer;

namespace Web_Presentation.Controllers
{
    public class ClassController : Controller
    {
        ClassBUS _classBus = new ClassBUS();

        //
        // GET: /Class/

        public ActionResult Index()
        {
            List<ClassDTO> listClassDTO = _classBus.GetList();
            List<Class> classes = new List<Class>();
            foreach (var classDto in listClassDTO)
            {
                classes.Add(new Class(classDto));
            }
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
                ClassDTO classDto = new ClassDTO();
                classDto.Name = c.Name;
                classDto.Code = c.Code;
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

                ClassDTO classDto = new ClassDTO();
                classDto.Id = c.Id;
                classDto.Name = c.Name;
                classDto.Code = c.Code;
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

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}