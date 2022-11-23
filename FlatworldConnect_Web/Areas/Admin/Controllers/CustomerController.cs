
using FlatworldConnect.DataAccess;
using FlatworldConnect.DataAccess.Repository.IRepository;
using FlatworldConnect.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlatworldConnect_Web.Areas.Admin.Controllers
{ 
[Area("Admin")]


public class CustomerController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<FlatworldConnect.Models.Customer> objCustomerList = _unitOfWork.Customer.GetAll();
        return View(objCustomerList);
    }

    //GET
    public IActionResult Create()
    {
        return View();
    }


    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(FlatworldConnect.Models.Customer obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Customer.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Customer added successfully";
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

        //var customerFromDb = _db.customers.Find(id);
        var customerFromDbFirst = _unitOfWork.Customer.GetFirstOrDefault(u => u.customerId == id);

        if (customerFromDbFirst == null)
        {
            return NotFound();
        }
        return View(customerFromDbFirst);
    }


    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(FlatworldConnect.Models.Customer obj)
    {


        if (ModelState.IsValid)
        {
            _unitOfWork.Customer.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Customer edited successfully";
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

        //var customerFromDb = _db.customers.Find(id);
        var customerFromDbFirst = _unitOfWork.Customer.GetFirstOrDefault(u => u.customerId == id);


        if (customerFromDbFirst == null)
        {
            return NotFound();
        }
        return View(customerFromDbFirst);
    }


    //POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _unitOfWork.Customer.GetFirstOrDefault(u => u.customerId == id);
        if (obj == null)
        {
            return NotFound();
        }

        _unitOfWork.Customer.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Customer deleted successfully";
        return RedirectToAction("Index");

    }
} }

