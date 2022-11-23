
using FlatworldConnect.DataAccess;
using FlatworldConnect.DataAccess.Repository.IRepository;
using FlatworldConnect.Models;
using FlatworldConnect.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace FlatworldConnect_Web.Areas.Vendor.Controllers
{ 
[Area("Vendor")]


public class ProjectController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ProjectController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        return View();
    }

         

        // GET
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _unitOfWork.Resource == null)
            {
                return NotFound();
            }

            var resource = _unitOfWork.Resource
                .GetFirstOrDefault(m => m.projectId == id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);


        }

        


        //GET
    //    public IActionResult Upsert(int? id)
    //{
    //        ProjectVM projectVM = new()
    //        {
    //            Project = new(),
    //            CustomerList = _unitOfWork.Customer.GetAll().Select(i => new SelectListItem
    //            {
    //                Text = i.customerName,
    //                Value = i.customerId.ToString()
    //            }),
    //            ProjectManagerList = _unitOfWork.ProjectManager.GetAll().Select(i => new SelectListItem
    //            {
    //                Text = i.PMName,
    //                Value = i.PMId.ToString()
    //            })
    //        };

    //        if (id == null || id == 0)
    //    {
    //            //create
    //            //ViewBag.CustomerList = CustomerList;
    //            //ViewData["ProjectManagerList"] = ProjectManagerList;
    //        return View(projectVM);
    //    }
    //        else
    //        {
    //            projectVM.Project = _unitOfWork.Project.GetFirstOrDefault(u => u.projectId == id);
    //            return View(projectVM);
    //            //update
    //        }

        
        
    //}


    //POST
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public IActionResult Upsert(ProjectVM obj)
    //{


    //    if (ModelState.IsValid)
    //    {
    //            if (obj.Project.projectId == 0)
    //            {
    //                _unitOfWork.Project.Add(obj.Project);
    //            }
    //            else
    //            {
    //                _unitOfWork.Project.Update(obj.Project);
    //            }
    //            _unitOfWork.Save();
    //        TempData["success"] = "Project created successfully";
    //        return RedirectToAction("Index");
    //    }
        

    //    return View(obj);
    //}

    ////GET
    //public IActionResult Delete(int? id)
    //{
    //    if (id == null || id == 0)
    //    {
    //        return NotFound();
    //    }

    //    var projectFromDbFirst = _unitOfWork.Project.GetFirstOrDefault(u => u.projectId == id);


    //    if (projectFromDbFirst == null)
    //    {
    //        return NotFound();
    //    }
    //    return View(projectFromDbFirst);
    //}


    ////POST
    //[HttpPost, ActionName("Delete")]
    //[ValidateAntiForgeryToken]
    //public IActionResult DeletePOST(int? id)
    //{
    //    var obj = _unitOfWork.Project.GetFirstOrDefault(u => u.projectId == id);
    //    if (obj == null)
    //    {
    //        return NotFound();
    //    }

    //    _unitOfWork.Project.Remove(obj);
    //    _unitOfWork.Save();
    //    TempData["success"] = "Project deleted successfully";
    //    return RedirectToAction("Index");

    //}

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var projectList = _unitOfWork.Project.GetAll(includeProperties: "Customer,PM");
            return Json(new { data = projectList });
        }

        //POST
        //[HttpDelete]
        //public IActionResult Delete(int? id)
        //{
        //    var obj = _unitOfWork.Project.GetFirstOrDefault(u => u.projectId == id);
        //    if (obj == null)
        //    {
        //        return Json(new { success = false, message = "Error while deleting!"});
        //    }

        //    _unitOfWork.Project.Remove(obj);
        //    _unitOfWork.Save();
        //    return Json(new { success = true, message = "Delete successful" });

        //}
        #endregion
    }




}

