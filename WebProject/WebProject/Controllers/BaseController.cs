using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.BusinessLogic;
using WebProject.BusinessLogic.Interfaces;
using WebProject.Domain.Enum;
using WebProject.ModelAccessLayer.Model;

namespace WebProject.Controllers
{
    public class BaseController : Controller
    {
        protected BusinessLogicFacade _businessLogic;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (Session["UserData"] != null)
            {
                var userData = (UserData)Session["UserData"];
                _businessLogic = new BusinessLogicFacade();
                _businessLogic.UpdateUser(userData);
            }
            else
            {
                _businessLogic = new BusinessLogicFacade();
            }
        }

        protected ActionResult CheckSessionAndReturnView(string viewName)
        {
            if (Session["UserData"] == null)
                return View(viewName);
            return RedirectToAction("Index", "Home");
        }

        protected ActionResult HandleUserAuthentication(object authData)
        {
            if (ModelState.IsValid)
            {
                UserData userData = null;

                if (authData is LoginData loginData)
                {
                    userData = ((IGuest)_businessLogic.User).Login(loginData);
                }
                else if (authData is RegistrationData registrationData)
                {
                    userData = ((IGuest)_businessLogic.User).Register(registrationData);
                }

                if (userData != null)
                {
                    Session["UserData"] = userData;
                    return RedirectToAction("Index", "Home");
                }

                ViewBag.ErrorMessage = "Invalid email or password";
                return View(authData);
            }

            ViewBag.ErrorMessage = "Invalid data";
            return View(authData);
        }

        protected bool IsAdmin()
        {
            return Session["UserData"] != null &&
                   ((UserData)Session["UserData"]).StatusUser == StatusUser.Admin &&
                   _businessLogic.User is IAdmin;
        }
    }
}