using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invco.Data.Entities;
using Invco.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Invco.Controllers
{
    public class Dashboard : Controller
    {
        private readonly IAssetService _ias;
        private readonly ICategoryService _cs;
        private readonly IDepartmentService _ds;
        private readonly UserManager<ApplicationUser> _userManager;

        public Dashboard(IAssetService ias, ICategoryService cs, IDepartmentService ds, UserManager<ApplicationUser> userManager)
        {
            _ias = ias;
            _cs = cs;
            _ds = ds;
            _userManager = userManager;
        }
        public IActionResult IndexDashboard()
        {
            ViewBag.Assets = _ias.GetAssetCount();
            ViewBag.Users = _userManager.Users.Count();
            ViewBag.Category = _cs.GetCategoryCount();
            ViewBag.Department = _ds.GetDepartmentCount();

            return View("Dashboard");
        }
    }
}

