using MovieRent.BLL.Repositories;
using MovieRent.DAL;
using MovieRent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
       
        CategoryRepository categoryRepository;
        MoviesRepository moviesRepository;
        UserAppListRepository listRepository;
        UserAppRepository users;

        public HomeController()
        {

            users = new UserAppRepository();
            listRepository = new UserAppListRepository();
            categoryRepository = new CategoryRepository();
            moviesRepository = new MoviesRepository();
        }

      
        public ActionResult Index()
        {

            //UserApp user = users.SelectByID(3);

            if (UserGiris())
            {
                return View(moviesRepository.SelectAll());
            }
            else
            {
                return RedirectToAction("LogIn", "AppUser");
            }
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
            else {
                Session["girisyap"] = null;
                return true; }
        }
        [HttpPost]
        public ActionResult Index(int id)
        {


            return View();
          
        }


        public ActionResult EditorSecimi()
        {

            if (UserGiris())
            {
                var result = moviesRepository.Where(x => x.AdminID == 1).ToList();


                return View(result);
            }
            else
            {
                return RedirectToAction("LogIn", "AppUser");
            }
            
        }
        
        public ActionResult UserList()
        {
            UserApp user = (UserApp)Session["login"];
            if (UserGiris())
            {
                var result = listRepository.Where(x => x.UserID == user.UserID && x.isActive == true).ToList();
                var result2 = moviesRepository.SelectAll();

                foreach (var item in result2)
                {
                    UserAppFilmList newobj = new UserAppFilmList();

                    foreach (var item2 in result)
                    {

                        if (item2.MovieID == item.MovieID)
                        {

                            newobj.MovieName = item.MovieName;
                            newobj.ListID = item2.ListID;
                            newobj.KiralaTarihi = item2.KiralaTarihi;
                            newobj.ListeTarihi = item2.ListeTarihi;
                            newobj.MovieID = item2.MovieID;
                            newobj.Oncelik = item2.Oncelik;
                            newobj.UserID = item2.UserID;
                            newobj.isActive = item2.isActive;
                            listRepository.Update(item2.ListID, newobj);

                        }
                    }
                }
                var result3 = listRepository.Where(x => x.UserID == user.UserID && x.isActive == true).ToList();
                var result4 = result3.OrderBy(x => x.Oncelik).ToList();
                return View(result4);
            }
            else
            {
                return RedirectToAction("LogIn", "AppUser");
            }


           
            //UserApp user = users.SelectByID(3);
           
        }
      
     //[HttpPost]
        public ActionResult UserListReorder(List<int> a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                listRepository.UpdateByID(listRepository.SelectByID(a[i]), i);

            }
            return RedirectToAction("UserList", "Home");
        }
        
        public ActionResult Delete(int id)
        {
            int a = id;
            UserAppFilmList filmList = listRepository.SelectByID(id);
            listRepository.ListeSil(filmList);
            return RedirectToAction("UserList", "Home");
        }
        

        public ActionResult Detail(int id)
        {
            Movies movie =  moviesRepository.SelectByID(id);
           
            return View(movie);

        }
        public ActionResult FilmAdd(int id)
        {
            Movies addmovie = moviesRepository.SelectByID(id);
            UserApp user = (UserApp)Session["login"];
            UserAppFilmList appFilmList = listRepository.SelectAll().Where(x => x.isActive == true && x.MovieID == id && x.UserID == user.UserID).FirstOrDefault();
            if (appFilmList == null)
            {

                listRepository.ListAddById(addmovie, user);
                return RedirectToAction("UserList", "Home");
            }
            else
            {
                TempData["HataliFilmSecimi"] = "Listenizde mevcut olan bir film seçtiniz. Lütfen başka bir film seçin.";
                return RedirectToAction("Index", "Home");
            }
            
            
  
        }
        public ActionResult Edit(int id)
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}