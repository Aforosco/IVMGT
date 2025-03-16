using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Invco.Models;
using Invco.Repository;
using Invco.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Invco.Service;

namespace Invco.Controllers;

public class HomeController : Controller
{
    private readonly IAssetService _ias;
    private readonly ICategoryService _cs;
    private readonly IDepartmentService _ds;
    private readonly UserManager<ApplicationUser> _userManager;
    public HomeController(IAssetService ias, ICategoryService cs, IDepartmentService ds, UserManager<ApplicationUser> userManager)
    {
        _ias = ias;
        _cs = cs;
        _ds = ds;
        _userManager = userManager;
    }

    
    public IActionResult Index()
    {
        

        return View();
    }

    [HttpGet]
    public IActionResult GetAllAssets()
    {
        var Assets = _ias.GetAllAsset();

        return View(Assets);
    }

    [HttpGet]
    public IActionResult GetAssetByDepartmentId(int Id)
    {
        var Assets = _ias.GetAllAssetByDepartmentId(Id);

        return View(Assets);
    }

    [HttpPost]

    public IActionResult InsertAsset(CreateAssetViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        _ias.InsertAsset(model);

        return View();
    }


    [HttpPost]

    public void DeleteAsset(int Id)
    {

        _ias.DeleteAsset(Id);


    }

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
            SerialNumber = Asset.SerialNumber,
            DepartmentId = Asset.DepartmentId,
            CategoryId = Asset.CategoryId   

        };

        return View(model);
    }

    [HttpPost]

    public IActionResult UpdateAssetViewModel(EditAssetViewModel eavm)
    {
        if (!ModelState.IsValid)
        {
            return View(eavm);
        }
        _ias.UpdateAsset(eavm);
        return RedirectToAction("GetAllAssets");


    }


    [HttpGet]
    public IActionResult GetAssetDetails(int Id)
    {
        var Asset = _ias.GetSingleAsset(Id);
        return View(Asset);

    }


    [HttpGet]
    public IActionResult GetCategories()
    {

        var cat = _cs.GetAllCategories();
        return View (cat);
    }

    [HttpPost]
    public void DeleteCategory(int Id)
    {

        _cs.DeleteCategory(Id);

    }


    [HttpPost]
    public IActionResult CreateCategory(CreateCategoryViewModel cvm)
    {
        if (!ModelState.IsValid)
            return View( cvm);
        _cs.InsertCategory(cvm);
        return RedirectToAction("GetCategories");
    }

    [HttpGet]
    public IActionResult GetDepartments()
    {

        var Dept = _ds.GetAllDepartments();
        return View(Dept);
    }

    [HttpPost]
    public void DeleteDepartment(int Id)
    {

        _ds.DeleteDepartment(Id);

    }


    [HttpPost]
    public IActionResult CreateDepartment(CreateDepartmentViewModel dvm)
    {
        if (!ModelState.IsValid)
            return View(dvm);
        _ds.InsertDepartment(dvm);
        return RedirectToAction("GetDepartments");
    }


}

