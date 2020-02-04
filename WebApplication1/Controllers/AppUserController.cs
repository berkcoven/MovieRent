using MovieRent.BLL.Repositories;
using MovieRent.COMMON.Helpers;
using MovieRent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication1.Controllers
{
    public class AppUserController : Controller
    {
        UserAppRepository userAppRepository = new UserAppRepository();
        PremiumRepository premiumRepository = new PremiumRepository();
        UserAppListRepository ualp = new UserAppListRepository();
        AdminRepository ap = new AdminRepository();
        // GET: AppUser
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register() {
           
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserApp user,FormCollection formCollection) {
            try
            {

                user.Userpremium = premiumRepository.SelectByID(Int32.Parse(formCollection.Get("PremiumID")));
                userAppRepository.Add(user);
//TODO:Sifre için farklı try catch 3 haneli sifre giriniz.
                user.KKSifre = Int32.Parse(formCollection.Get("KKSifre"));
                OdemeAl(user.KKNo, user.KKSonKullanma, user.KKSifre, user.Userpremium);
                string body = "MovieRent film kiralama sitesine hoşgeldiniz sayın"+user.UserName+ ". Activasyon İçin Linke Tıklayınız http://localhost:53399/AppUser/UserActivation/?id="+user.UserID;
                Mailer.Send(user.Email, body, "MovieRent'e Hoşgeldiniz!");


                return RedirectToAction("LogIn", "AppUser");


            }
            catch (Exception ex)
            {
                TempData["KayitHata"] = ex.Message;

                return RedirectToAction("Register", "AppUser");
            }
          
        }

        public ActionResult UserActivation(int id)
        {
            UserApp user = userAppRepository.SelectByID(id);
            user.isActive = true;
            userAppRepository.Update(id, user);

            return RedirectToAction("LogIn", "AppUser");
        }
        public void OdemeAl(string KKno,string KKsk,int KKSifre,Premiums premium)
        {
            //Ödeme alma işlemi
        }

        public ActionResult LogIn()
        {
            if (Session["login"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else{

                return View();
            }
          
        }
        [HttpPost]
        public ActionResult LogIn(UserApp model)
        {
            var user = userAppRepository.SelectAll().Where(x => x.UserName == model.UserName && x.Sifre == model.Sifre).FirstOrDefault();

            if (user == null)
            {
                TempData["HatalıGiris"] = "Kullanıcı Adınız Veya Parolanız Hatalı, Lütfen Tekrar Deneyiniz.";
                return RedirectToAction("LogIn", "AppUser");
            }
            else 
            {
                if (user.isActive == false) { TempData["HesapActive"] = "Hesabınızı mailinize gelen linkten aktif ediniz";
                    return RedirectToAction("LogIn", "AppUser");
                }
                else
                {



                    //Session
                    Session["login"] = user;
                    Session["KAdi"] = user.UserName + " " + user.UserLastName;
                    FormsAuthentication.SetAuthCookie(user.UserName, true);

                    if (ualp.SelectAll().Where(x => x.UserID == user.UserID && x.isActive == true).Count() < 10)
                    {
                        TempData["ListMinTen"] = "Lütfen listenize en az 10 adet film ekleyiniz";
                    }
                    return RedirectToAction("Index", "Home");
                }
            }

          

        }

        public ActionResult LogOut()
        {
           
                FormsAuthentication.SignOut();
                Session.Abandon(); // it will clear the session at the end of request
                return RedirectToAction("LogIn", "AppUser");
            
        }

        public void OdemeAlAylik(UserApp user)
        {
            try
            {
                DateTime dt = user.UyeOlmeTarihi;
                TimeSpan ts = DateTime.Now.Subtract(dt);
                if (ts.Days >= 30)
                {
                    OdemeAl(user.KKNo, user.KKSonKullanma, user.KKSifre, user.Userpremium);
                }

            }
            catch (Exception ex)
            {

                string body = "Kredi kartınızdan üyelik ücreti çekilemedi nedeni: "+ex.Message;
                Admin admin = ap.SelectByID(2);
                
                Mailer.Send(user.Email, body, "Üyelik Ücreti Çekim Hatası");
                Mailer.Send(admin.AdminEmail, body, "Üyelik Ücreti Çekim Hatası");
                
            }
           
        }

    }
}