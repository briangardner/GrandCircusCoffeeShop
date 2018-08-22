using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrandCircusCoffeeShop.Models;
using GrandCircusCoffeeShop.Models.Home;

namespace GrandCircusCoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        private const string CartCookieName = "ShoppingCart";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            return View("CreateRegistration");
        }

        [HttpPost]
        public ActionResult Register(Registration registration)
        {
            var vm = new WelcomeViewModel()
            {
                FirstName = registration.FirstName,
                FavoriteCoffee = registration.FavoriteCoffee
            };
            /*ViewBag.FirstName = registration.FirstName;
            ViewBag.FavoriteCoffee = registration.FavoriteCoffee;*/
            return View("Welcome", vm);
        }

        [HttpPost]
        public ActionResult Welcome(WelcomeViewModel vm)
        {
            HttpCookie cookie;
            if (Request.Cookies[CartCookieName] == null)
            {
                cookie = new HttpCookie(CartCookieName, "0");

            }
            else
            {
                cookie = Request.Cookies[CartCookieName];
            }

            var coffeeOrders = int.Parse(cookie.Value);
            ++coffeeOrders;
            cookie.Value = coffeeOrders.ToString();
            Response.Cookies.Add(cookie);
            return View("Welcome", vm);
        }

        public ActionResult EmptyCart(WelcomeViewModel vm)
        {
            Request.Cookies.Remove(CartCookieName);
            return View("Welcome", vm);
        }

    }
}