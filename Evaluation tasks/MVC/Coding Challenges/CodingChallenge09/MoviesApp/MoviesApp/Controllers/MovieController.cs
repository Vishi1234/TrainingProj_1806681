
using MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie_Mvc.Controllers
{
    public class MoviesController : Controller
    {
        private IMovieRepository repo = new MovieRepo();


        public ActionResult Index()
        {
            var movies = repo.GetAll();
            return View(movies);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movies movie)
        {
            if (ModelState.IsValid)
            {
                repo.Add(movie);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = repo.GetById(id);
            if (movie == null) return HttpNotFound();
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movies movie)
        {
            if (ModelState.IsValid)
            {
                repo.Update(movie);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        public ActionResult Delete(int id)
        {
            var movie = repo.GetById(id);
            if (movie == null) return HttpNotFound();
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            repo.Save();
            return RedirectToAction("Index");
        }


        public ActionResult MoviesByYear(int year)
        {
            var movies = repo.MoviesByYear(year);
            return View("Index", movies);
        }


        public ActionResult MoviesByDirector(string directorName)
        {
            var movies = repo.MoviesByDirector(directorName);
            return View("Index", movies);
        }
    }
}
