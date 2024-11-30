using FrontEndApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FrontEndApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        CarSystemEntities carSystemEntities = new CarSystemEntities();

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Register()
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (carSystemEntities.UserDatas.Any(x => x.Email != user.UserEmail))
                {


                    UserData userData = new Models.UserData();
                    userData.Username = user.UserName;
                    userData.Email = user.UserEmail;
                    userData.Contact = user.UserContact;
                    userData.Password = user.UserPassword;
                    userData.City = user.UserCity;
                    LoginModel loginModel = new LoginModel();
                    carSystemEntities.UserDatas.Add(userData);
                    carSystemEntities.SaveChanges();

                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.Notification = "This Account is already exist";
                    return View();

                }
            }


            
            return View();
        }
        public ActionResult Login()
        {
            LoginModel loginModel = new LoginModel();
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserData userData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (carSystemEntities.UserDatas.Where(m => m.Email == userData.Email && m.Password == userData.Password).FirstOrDefault() != null)
                    {

                        //UserData userdata = new Models.UserData();
                        Session["Email"] = userData.Email;
                        //Session["res"] = loginModel.ID;
                        TempData["UserId"]=userData.UserId;
                        return RedirectToAction("UserHome", "Account");

                    }
                    else
                    {
                        ViewBag.Notification = "Wrong User Name Or Password";

                    }
                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }
            //Session["Email"] = "abc@gmail.com";
            //return RedirectToAction("UserHome", "Account");

        }



        public ActionResult UserHome()
        {
            return View();
        }

        public ActionResult SellCar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SellCar(Car carDetails)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    if (carSystemEntities.Cars.Any(x => x.CarNo != carDetails.CarNo))
                    {
                        ViewBag.Notification = "Car Details Already exist!";

                    }
                    else
                    {

                        var Uid = TempData["UserId"];

                        UserData userData = new UserData();
                        string fileName = Path.GetFileNameWithoutExtension(carDetails.ImageFile.FileName);
                        string extension = Path.GetExtension((carDetails.ImageFile.FileName));
                        HttpPostedFileBase postedfile = carDetails.ImageFile;
                        fileName = fileName + extension;
                        carDetails.CarImage = "../Images/" + fileName;
                        fileName = Path.Combine(Server.MapPath("../Images/"), fileName);
                        carDetails.ImageFile.SaveAs(fileName);
                        carDetails.CarVerified = false;
                        carDetails.CarSold = false;
                        carDetails.CarUid = Convert.ToInt32(Uid);
                        carSystemEntities.Cars.Add(carDetails);
                        carSystemEntities.SaveChanges();
                        return RedirectToAction("UserHome", "Account");
                    }


                }

            }
            catch (Exception e)
            {

                throw;



            }
            return View();
        }

        public ActionResult BuyCar()
        {
            var res = carSystemEntities.Cars.Where(item => item.CarVerified == true).ToList();

            return View(res);
            //var res = carSystemEntities.Cars.ToList();
        }


        public ActionResult Book(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = carSystemEntities.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Book([Bind(Include = "CarNo,CarImage,CarName,CarModel,CarYear,CarType,NoOfOwners,CarVerified,CarSold,CarUid,City")] Car car)
        {
            if (ModelState.IsValid)
            {
                // car.CarSold=true;
                carSystemEntities.Entry(car).State = EntityState.Modified;
                carSystemEntities.SaveChanges();
                return RedirectToAction("BuyCar");
            }
            return View(car);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("UserHome", "Account");
        }

    }
}