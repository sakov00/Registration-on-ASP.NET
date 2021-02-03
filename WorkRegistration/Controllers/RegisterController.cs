using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkRegistration.Models;

namespace WorkRegistration.Controllers
{
    
    public class RegisterController : Controller
    {
        private static UserModel model = new UserModel();
        public static UserContactInfo usercont = new UserContactInfo();
        public static UserInfo user = new UserInfo();
        public static UserBusinessAreas userbusis = new UserBusinessAreas();
        public static UserAddress useradr = new UserAddress();

        // GET: Register
        public ActionResult ContactInfo()
        {
                return View(model);
        }
        [HttpPost]
        public ActionResult ContactInfo(UserModel model,string Salutation)
        {
            model.Info.Salutation = Salutation;
            usercont = model.Contact;
            user = model.Info;
            if (user.Salutation!=""&& user.FirstName!=null&& user.LastName != null && user.Company != null && user.Title != null
                && usercont.Email!=null && usercont.ConfirmEmail != null && usercont.Phone != null)
            {
                return Redirect("/Register/Areas");
            }
            return View(model);
        }
        public ActionResult Areas()
        {
            return View(model);
        }
        [HttpPost]
        public ActionResult Areas(string Back, string Next, UserModel model)
        {
            userbusis = model.Areas;
            if (Back == "BACK")
                return Redirect("/Register/ContactInfo");
            if (Next == "NEXT"&& (userbusis.Finance==true|| userbusis.Operations == true || userbusis.IT == true || userbusis.Sales == true ||
                userbusis.Administrative == true || userbusis.Legal == true || userbusis.Marketing == true)&&userbusis.Comment!=null)
                return Redirect("/Register/Address");
            return View(model);
        }

        public ActionResult Address()
        {
            return View(model);
        }
        [HttpPost]
        public ActionResult Address(string Back, string Next, UserModel model, string Country, string State)
        {
            model.Address.Country = Country;
            model.Address.State = State;
            useradr = model.Address;
            if (Back == "BACK")
                return Redirect("/Register/Areas");
            if (Next == "NEXT" && useradr.Country!="" && useradr.OfficeName != null && useradr.Address != null &&useradr.PostalCode!=null &&
                useradr.City != null && useradr.State != "")
            return Redirect("/Register/Password");
            return View(model);
        }
        public ActionResult Captcha()
        {
            int v1 = new Random().Next(50,99);
            int v2 = new Random().Next(10,50);
            string code = v1.ToString()+"-"+v2.ToString()+"=?";
            Session["code"] = code;
            CaptchaImage captcha = new CaptchaImage(code, 300, 75);

            this.Response.Clear();
            this.Response.ContentType = "image/jpeg";

            captcha.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);

            captcha.Dispose();
            return null;
        }
        public ActionResult Password()
        {
            return View(model);
        }
        [HttpPost]
        public ActionResult Password(UserModel model, string BACK, string NEXT,string Agreement)
        {
            ViewBag.Message = Agreement;
            usercont.Password= model.Contact.Password;
            usercont.ConfirmPassword = model.Contact.ConfirmPassword;
            int v1 = int.Parse(Session["code"].ToString().Substring(0,2));
            int v2 = int.Parse(Session["code"].ToString().Substring(3, 2));
            int result = v1 - v2;
            usercont.Captcha = result.ToString();
            if (BACK == "BACK")
                return Redirect("/Register/Address");
            if (model.Contact.Captcha != result.ToString())
            {
                ModelState.AddModelError("Captcha", "Текст с картинки введен неверно");
            }
            else if (NEXT == "NEXT" && model.Contact.Password!=null&& model.Contact.ConfirmPassword != null&& model.Contact.Password== model.Contact.ConfirmPassword && Agreement=="true") 
                    return Redirect("/Register/Completed");
            return View(model);
        }

        public ActionResult Completed()
        {
            using (UserContext db = new UserContext())
            {                
                db.UserInfo.Add(user);
                db.UserContactInfo.Add(usercont);//сделай так чтобы капча не сохранялась в бд
                db.UserBusinessAreas.Add(userbusis);
                db.UserAddresses.Add(useradr);
                db.SaveChanges();
            }
            return View();
        }

    }
}
