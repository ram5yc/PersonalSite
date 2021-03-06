﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalSiteRM.UI.MVC.Models; //entered using statement to have access to Family Member View Model and Contact View Model
//added below using statements for contact form functionality
using System.Net; //for network creds
using System.Net.Mail;

namespace PersonalSiteRM.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
        //Post Contact Action 

        public PartialViewResult EmailConfirm (string name, string email)
        {
            ViewBag.Name = name;
            ViewBag.Email = email;

            return PartialView("EmailConfirm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ContactAjax(ContactViewModel cvm)
        {
            string body = $"You have received an email from {cvm.Name} with a subject of {cvm.Subject}. Please respond to {cvm.Email} with your response to the following message: <br/> {cvm.Message}";

            MailMessage m = new MailMessage(
                "webadmin@rachelmantei.com",
                "webdevrach@gmail.com",
                cvm.Subject,
                body
                );

            m.IsBodyHtml = true;

            m.Priority = MailPriority.High;

            m.ReplyToList.Add(cvm.Email);

            SmtpClient client = new SmtpClient("mail.rachelmantei.com");

            client.Credentials = new NetworkCredential("webadmin@rachelmantei.com", "P@ssw0rd");

            try
            {
                client.Send(m);
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"We're sorry your request could not be sent at this time. Please try again later. <br/> Error Message:<br/> {ex.StackTrace}";
            }
            return Json(cvm);
        }//end if

        public ActionResult Resume()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Portfolio()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Classmates()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }//end action
}
