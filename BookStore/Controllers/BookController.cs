using BookStore.DAL;
using BookStore.DAL.Repositories;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository _bookRepository;
        public BookController()
        {
            this._bookRepository = new BookRepository(new BookContext());
        }

        public ActionResult Index()
        {
            BookViewModel model = new BookViewModel(_bookRepository);
            return View(model);
        }



        #region New

        [HttpGet]
        public ActionResult New()
        {
            NewBookViewModel model = new NewBookViewModel(_bookRepository);
            return View(model);       
        }

        [HttpPost]
        public ActionResult New(NewBookViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Save(_bookRepository))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                   ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            return View(model);
        }

        #endregion


        #region Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EditViewModel model = new EditViewModel(_bookRepository,id);
            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Save(_bookRepository))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            return View(model);
        }



        #endregion

        #region Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            DeleteViewModel model = new DeleteViewModel(_bookRepository,id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(DeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Save(_bookRepository))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        #endregion
    }
}