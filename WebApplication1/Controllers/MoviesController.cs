using MovieRent.BLL.Repositories;
using MovieRent.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
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
            var result =moviesRepository.SelectAll().Where(x => x.MovieName.ToUpper().Contains(id.ToUpper())||x.Director.ToUpper().Contains(id.ToUpper())||x.Actors.ToUpper().Contains(id.ToUpper())).ToList();
            if (result.Count == 0)
            {
                TempData["AramaHatasi"] = "Aradığınız kriterlere uygun film bulunamadı.";
            }
            return View(result);
        }

        public ActionResult SiparisVer(string id)
        {
            DateTime dt = DateTime.ParseExact(id, "dd-MM-yyyy", null);
           
            UserApp user = (UserApp)Session["login"];
            List<UserAppFilmList> uap = listRepository.SelectAll().Where(x => x.UserID == user.UserID&&x.isActive==true).ToList();
            moviesRepository.KiralaTarihi(uap, dt);
            var userorderlist = listRepository.SelectAll().Where(x => x.UserID == user.UserID && x.isActive == true&&x.KiralaTarihi!=null).OrderBy(x=>x.Oncelik).ToList();
            return View(userorderlist);
        }
        public ActionResult EnCokKiralanan()
        {
            List<UserAppFilmList> uafl = listRepository.SelectAll().Where(x=>x.isActive==true).ToList();

            List<MostViewedModel> Kiralanan = uafl.GroupBy(x => x.MovieID).Select(y => new MostViewedModel() {MovieId=y.Key,Count = y.Count(),Movie=moviesRepository.SelectByID(y.Key) }).ToList();

            return View(Kiralanan);
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