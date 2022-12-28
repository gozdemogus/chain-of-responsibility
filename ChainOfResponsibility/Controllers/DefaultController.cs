using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChainOfResponsibility.ChainOfResponsibility;
using Microsoft.AspNetCore.Mvc;
using UpSchool_ChainOfResponsibility.ChainOfResponsibility;
using UpSchool_ChainOfResponsibility.DAL.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChainOfResponsibility.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(WithdrawViewModel p)
        {
            Employee treasurer = new Treasurer();
            Employee managerAssistant = new ManagerAssistant();
            Employee manager = new Manager();
            Employee regionManager = new RegionManager();

            treasurer.SetNextApprover(managerAssistant);
            managerAssistant.SetNextApprover(manager);
            manager.SetNextApprover(regionManager);

            treasurer.ProcessRequest(p);

            return View();
        }
    }
}

