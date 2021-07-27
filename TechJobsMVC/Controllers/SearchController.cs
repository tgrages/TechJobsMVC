using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Controllers;
using TechJobsMVC.Models;
using TechJobsMVC.Data;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        private static List<Job> _jobsList;
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view. Should be able to go to search and type a skill in to bring back all jobs utilizing that skill. 

        public IActionResult Results(string searchType, string searchTerm)
        {
            //if statement?
            if (String.IsNullOrEmpty(searchTerm))
            {
                _jobsList = JobData.FindAll();
            }

            else
            {
                _jobsList = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            ViewBag.jobs = _jobsList;
            ViewBag.columns = ListController.ColumnChoices;

            return View("~/Views/Search/Index.cshtml");
        }
    }
}
