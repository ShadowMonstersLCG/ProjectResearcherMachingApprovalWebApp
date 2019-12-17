using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectResearcherMachingApprovalWebApp.Controllers
{
    public class NotifyController : Controller
    {
        // GET: Notify
        public ActionResult Index()
        {
            return Redirect("http://ec2-54-159-208-218.compute-1.amazonaws.com:8080/java-mvc-webapp/snsnotification");
            //return Content("<script>window.location = 'http://ec2-54-159-208-218.compute-1.amazonaws.com:8080/java-mvc-webapp/snsnotification';</script>");
        }
    }
}