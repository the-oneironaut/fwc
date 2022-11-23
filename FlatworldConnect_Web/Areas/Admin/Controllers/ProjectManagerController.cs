
using FlatworldConnect.DataAccess;
using FlatworldConnect.DataAccess.Repository.IRepository;
using FlatworldConnect.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlatworldConnect_Web.Areas.Admin.Controllers
{ 
[Area("Admin")]


public class ProjectManagerController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ProjectManagerController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<ProjectManager> objProjectManagerList = _unitOfWork.ProjectManager.GetAll();
        return View(objProjectManagerList);
    }

    //GET
    public IActionResult Create()
    {
        return View();
    }


    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ProjectManager obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.ProjectManager.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Project Manager added successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    //GET
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var projectManagerFromDbFirst = _unitOfWork.ProjectManager.GetFirstOrDefault(u => u.PMId == id);

        if (projectManagerFromDbFirst == null)
        {
            return NotFound();
        }
        return View(projectManagerFromDbFirst);
    }


    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(ProjectManager obj)
    {


        if (ModelState.IsValid)
        {
            _unitOfWork.ProjectManager.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Project Manager edited successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    //GET
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var projectManagerFromDbFirst = _unitOfWork.ProjectManager.GetFirstOrDefault(u => u.PMId == id);


        if (projectManagerFromDbFirst == null)
        {
            return NotFound();
        }
        return View(projectManagerFromDbFirst);
    }


    //POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _unitOfWork.ProjectManager.GetFirstOrDefault(u => u.PMId == id);
        if (obj == null)
        {
            return NotFound();
        }

        _unitOfWork.ProjectManager.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Project Manager deleted successfully";
        return RedirectToAction("Index");

    }
} }

