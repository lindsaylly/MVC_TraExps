using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCApp.Models;
using static DataLibrary.BusinessLogic.CustomerProcessor;
using static DataLibrary.BusinessLogic.CountryProcessor;
using static DataLibrary.BusinessLogic.ProvinceProcessor;
using static DataLibrary.BusinessLogic.UserProcessor;
using DataLibrary.Models;
using Scrypt;

namespace MVCApp.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            ScryptEncoder encoder = new ScryptEncoder();
            try
            {
                var validUser = GetUser(model.UserName);

                if (validUser == null)
                {
                    ViewBag.result = "User email or password is invaild.";
                    return View();
                }
                bool isValidUser = encoder.Compare(model.UserPassword, validUser.UserPassword);
                if (isValidUser)
                {
                    Session["userName"] = validUser.UserName;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.result = "User email or password is invaild.";
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.Result = e.Message;
                return View();
            }
        }

        public ActionResult MyAccount()
        {
            ViewBag.Message = "Update the Profile";
            if (Session["userName"] != null)
            {
                string email = Convert.ToString(Session["userName"]);
                var data = GetCustomer(email);
                CustomerModel cust = new CustomerModel();
                cust.FirstName = data.CustFirstName;
                cust.LastName = data.CustLastName;
                cust.Address = data.CustAddress;
                cust.Province = data.CustProv;
                cust.City = data.CustCity;
                cust.Postal = data.CustPostal;
                cust.Country = data.CustCountry == null ? "Canada" : data.CustCountry;
                cust.HomePhone = data.CustHomePhone;
                cust.BusinessPhone = data.CustBusPhone;

                List<Country> CountryList = LoadCountry();
                ViewBag.CountryList = new SelectList(CountryList, "CountryName", "CountryName", cust.Country);
                List<Province> ProvinceList = LoadProvince(cust.Country);
                ViewBag.ProvinceList = new SelectList(ProvinceList, "ProvAbbr", "ProvName", cust.Province);

                return View(cust);
            }
            else
                return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MyAccount(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Email = Session["UserName"].ToString();
                    int affectedRows = UpdateCustomer(model.FirstName,
                                        model.LastName,
                                        model.Address,
                                        model.City,
                                        model.Province,
                                        model.Postal,
                                        model.Country,
                                        model.HomePhone,
                                        model.BusinessPhone,
                                        model.Email,
                                        model.AgentId);

                    if (affectedRows >0) 
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception e)
                {
                    ViewBag.Result = e.Message;
                }
            }

            List<Country> CountryList = LoadCountry();
            ViewBag.CountryList = new SelectList(CountryList, "CountryName", "CountryName");
            if (model.Country != null)
            {
                List<Province> ProvinceList = LoadProvince(model.Country);
                ViewBag.ProvinceList = new SelectList(ProvinceList, "ProvAbbr", "ProvName");
            }

            return View(model);
        }


        public ActionResult SignUp()
        {
            ViewBag.Message = "Customer Sign up";

            List<Country> CountryList = LoadCountry();
            ViewBag.CountryList = new SelectList(CountryList, "CountryName", "CountryName");

            return View();
        }

        public JsonResult GetProvinceList(string countryName)
        {
            List<Province> ProvinceList = LoadProvince(countryName);
            return Json(ProvinceList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(CustomerModel model)
        {
            ScryptEncoder encoder = new ScryptEncoder();
            if (model.Email == null)
            {
                ModelState.AddModelError("Email", "Required");
            }
            if (model.Password == null)
            {
                ModelState.AddModelError("Password", "Required");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int affectedRows = CustomerRegister(
                                    model.FirstName,
                                    model.LastName,
                                    model.Address,
                                    model.City,
                                    model.Province,
                                    model.Postal,
                                    model.Country,
                                    model.HomePhone,
                                    model.BusinessPhone,
                                    model.Email,
                                    encoder.Encode(model.Password)
                                    );
                    if (affectedRows > 0)
                    {
                        ViewBag.Result = "Registered successfully. You can login now.";
                        return View();
                    }
                    else
                    {
                        ViewBag.result = "The email address is already registered.";
                    }

                }
                catch (Exception e)
                {
                    ViewBag.Result = e.Message;
                }
            }

            List<Country> CountryList = LoadCountry();
            ViewBag.CountryList = new SelectList(CountryList, "CountryName", "CountryName");

            if (model.Country != null)
            {
                List<Province> ProvinceList = LoadProvince(model.Country);
                ViewBag.ProvinceList = new SelectList(ProvinceList, "ProvAbbr", "ProvName");
            }
            model.Password = null;
            model.ConfirmPassword = null;
            return View(model);
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}