using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Invco.Models;
using Invco.Repository;
using Invco.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Invco.Service;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.ConstrainedExecution;

namespace Invco.Controllers;

public class HomeController : Controller
{
    private readonly IAssetService _ias;
    private readonly ICategoryService _cs;
    private readonly IDepartmentService _ds;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    public HomeController(IAssetService ias, ICategoryService cs, IDepartmentService ds, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _ias = ias;
        _cs = cs;
        _ds = ds;
        _userManager = userManager;
         _roleManager = roleManager;
    }

    
    public IActionResult Index()
    {
        

        return View();
    }

    [HttpGet]
    public IActionResult GetAllAssets(int page = 1, string SortColumn ="Id", string IconClass = "fa-sort-asc")
    {
        ViewBag.IconClass = IconClass;
        ViewBag.SortColumn = SortColumn;
        var Assets = _ias.GetAllAsset(page, SortColumn, IconClass);


        return View(Assets);
    }
    [HttpGet]
    public async Task<IActionResult> GetAssetByDepartmentId(int page = 1)
    {
        var userId = _userManager.GetUserId(User);
        if (userId == null)
        {
            return Unauthorized("User not found.");
        }

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound("User not found.");
        }

        var roleNames = await _userManager.GetRolesAsync(user);

        var roleIds = _roleManager.Roles
            .Where(r => roleNames.Contains(r.Name ?? ""))
            .Select(r => r.Id)
            .ToList();

        if (!roleIds.Any())
        {
            return BadRequest("User has no assigned roles.");
        }

        var roleId = roleIds.First();
        int Id = 5; 

        
        if (roleId == "e3ec8678-e509-40dc-96a0-221f0c8f4382")
        {
            Id = 1;
        }
        else if (roleId == "7affaec9-895b-4aa2-ac6b-26a3c7ca47a4")
        {
            Id = 2;
        }
        else if (roleId == "69b16bf1-71f0-4164-993f-b1d76162a8ad")
        {
            Id = 3;
        }
        else if (roleId == "3313c89d-7dcc-4cee-b6ad-79826808928d")
        {
            Id = 4;
        }


        var assets = _ias.GetAllAssetByDepartmentId(Id, page);
        
        return View(assets);
    }



    [Authorize(Roles = "Admin")]
    [HttpGet]
    public IActionResult InsertAsset()
    {
        ViewBag.Categories = _cs.GetAllCategories().Categories;
        ViewBag.Departments = _ds.GetAllDepartments().departments;

        return View();
    }


    [Authorize(Roles = "Admin")]
    [HttpPost]

    public IActionResult InsertAsset(CreateAssetViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = _cs.GetAllCategories().Categories ?? new List<CategoryViewModel>();
            ViewBag.Departments = _ds.GetAllDepartments().departments ?? new List<DepartmentViewModel>();
            return View(model);
        }
      
        _ias.InsertAsset(model);

        return RedirectToAction("GetAllAssets");
    }


    [Authorize(Roles = "Admin")]
    [HttpPost]

    public void DeleteAsset(int Id)
    {

        _ias.DeleteAsset(Id);


    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public IActionResult UpdateAssetViewModel(int Id)
    {
        var Asset = _ias.GetSingleAsset(Id);
        if (Asset == null)
            return NotFound();

        var model = new EditAssetViewModel
        {
            AssetName = Asset.AssetName,
            AssetUser = Asset.AssetUser,
            Purchasedate = Asset.Purchasedate,
            SerialNumber = Asset.SerialNumber,
            CategoryId = Asset.CategoryId,
            CategoryName = Asset.CategoryName,
            DepartmentId = Asset.DepartmentId,
            DepartmentName = Asset.CategoryName
        };

        // Fetch categories and departments for dropdowns
        ViewBag.Categories = _cs.GetAllCategories().Categories
                                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.CategoryName })
                                .ToList();

        ViewBag.Departments = _ds.GetAllDepartments().departments
                          .Select(d => new SelectListItem
                          {
                              Value = d.Id.ToString(),
                              Text = d.DepartmentName
                          })
                          .ToList();

        return View(model);
    }


    [Authorize(Roles = "Admin")]
    [HttpPost]
    public IActionResult UpdateAssetViewModel(EditAssetViewModel eavm)
    {
        if (!ModelState.IsValid)
        {
            // Reload dropdown lists
            ViewBag.Categories = _cs.GetAllCategories().Categories
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.CategoryName })
                .ToList();

            ViewBag.Departments = _ds.GetAllDepartments().departments
                .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.DepartmentName })
                .ToList();

            return View(eavm);
        }

        _ias.UpdateAsset(eavm);
        return RedirectToAction("GetAllAssets");
    }
    [Authorize]
    [HttpGet]
    public IActionResult GetAssetDetails(int Id)
    {
        var Asset = _ias.GetSingleAsset(Id);
        return View(Asset);

    }


    [Authorize(Roles = "Admin")]
    [HttpGet]
    public IActionResult GetCategories()
    {

        var cat = _cs.GetAllCategories();
        return View (cat);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public void DeleteCategory(int Id)
    {

        _cs.DeleteCategory(Id);

    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public IActionResult CreateCategory()
    {

        return View();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public IActionResult CreateCategory(CreateCategoryViewModel cvm)
    {
        if (!ModelState.IsValid)
            return View( cvm);
        _cs.InsertCategory(cvm);
        return RedirectToAction("GetCategories");
    }


    [Authorize(Roles = "Admin")]
    [HttpGet]
    public IActionResult GetDepartments()
    {

        var Dept = _ds.GetAllDepartments();
        return View(Dept);
    }


    [Authorize(Roles = "Admin")]
    [HttpPost]
    public void DeleteDepartment(int Id)
    {

        _ds.DeleteDepartment(Id);
        
    }


    [Authorize(Roles = "Admin")]
    [HttpGet]
    public IActionResult CreateDepartment()
    {
       
        return View();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public IActionResult CreateDepartment(CreateDepartmentViewModel dvm)
    {
        if (!ModelState.IsValid)
            return View(dvm);
        _ds.InsertDepartment(dvm);
        return RedirectToAction("GetDepartments");
    }


}

