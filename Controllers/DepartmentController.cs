using EFCoreWithAsp.netCore.Repositories;
using EFCoreWithAsp.netCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreWithAsp.netCore.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return View(departments);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(DepartmentViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model); 
            }
            
            await _departmentRepository.AddAsync(model);
            return RedirectToAction("Index", "Department");
        }

        //GET: /Department/Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            return View(department);
        }

        //POST: /Department/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentViewModel department)
        {

            if (ModelState.IsValid)
            {
                await _departmentRepository.UpdateAsync(department);

                return RedirectToAction("Index", "Department");
            }
            return View(department);
        }

        //GET: /Department/Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _departmentRepository.DeleteAsync(id);

            return RedirectToAction("Index", "Department");
        }
    }
}
