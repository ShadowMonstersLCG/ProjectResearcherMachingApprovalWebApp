using ProjectResearcherMachingApprovalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ProjectResearcherMachingApprovalWebApp.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        [HttpGet]
        public ActionResult Index()
        {
            var ApiBaseUri = ConfigurationManager.AppSettings["ApiBaseUri"] + "api/";

            IEnumerable<ProjectViewModel> projects = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiBaseUri);
                //HTTP GET
                var responseTask = client.GetAsync("Project");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ProjectViewModel>>();
                    readTask.Wait();

                    projects = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    projects = Enumerable.Empty<ProjectViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

           return View(projects);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Detail()
        {

            var ApiBaseUri = ConfigurationManager.AppSettings["ApiBaseUri"] + "api/";

            IEnumerable<ProjectViewModel> projects = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiBaseUri);
                //HTTP GET
                var responseTask = client.GetAsync("Project");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ProjectViewModel>>();
                    readTask.Wait();

                    projects = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    projects = Enumerable.Empty<ProjectViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View(projects);
        }
    }
}