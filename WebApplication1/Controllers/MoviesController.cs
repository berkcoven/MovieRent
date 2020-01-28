using MovieRent.BLL.Repositories;
using MovieRent.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        CategoryRepository categoryRepository;
        MoviesRepository moviesRepository;
        UserAppListRepository listRepository;
        UserAppRepository users;


        public MoviesController()
        {
            users = new UserAppRepository();
            listRepository = new UserAppListRepository();
            categoryRepository = new CategoryRepository();
            moviesRepository = new MoviesRepository();
        }
        public ActionResult Index()
        {
            if (UserGiris())
            {
                CategoryFilms cf = new CategoryFilms();
                cf.categories = categoryRepository.SelectAll();
                cf.movies = moviesRepository.SelectAll();

                return View(cf);
                
            }
            else
            {
                return RedirectToAction("LogIn", "AppUser");
            }


            

        }
        [HttpPost]
        public ActionResult Index(CategoryFilms categoryFilms)
        {
            categoryFilms.categories = categoryRepository.SelectAll();
            categoryFilms.movies = moviesRepository.SelectAll();
            if (categoryFilms.selectedCatId!=0)
            {
                categoryFilms.movies= categoryFilms.movies.Where(x => x.CategoryID == categoryFilms.selectedCatId).ToList();
            }
            return View(categoryFilms); 
        }

        public PartialViewResult FilmLists()
        {

            return PartialView();
        }


        public ActionResult SearchWithName(string id)   
        {
            var result =moviesRepository.SelectAll().Where(x => x.MovieName.ToUpper().Contains(id.ToUpper())).ToList();
            if (result.Count == 0)
            {
                TempData["AramaHatasi"] = "Aradığınız kriterlere uygun film bulunamadı.";
            }
            return View(result);
        }
        public bool UserGiris()
        {
            UserApp user = (UserApp)Session["login"];
            Session["login"] = user;
            if (Session["login"] == null)
            {
                Session["girisyap"] = "Önce Giriş Yapınız";

                return false;
            }
            else
            {
                Session["girisyap"] = null;
                return true;
            }
        }

    }
}