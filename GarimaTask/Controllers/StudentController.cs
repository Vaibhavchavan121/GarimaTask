using GarimaTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;

namespace GarimaTask.Controllers
{
    public class StudentController : Controller
    {
        AppDbContext _db;

        public StudentController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var student = _db.Students.ToList();
            StudentVM vm = new StudentVM();
            vm.StudentsList = student;
            List<Cities> citites = new List<Cities>()
            {
                 new Cities(){Id=1,Name="Pune"},
                 new Cities(){Id=2,Name="Mumbai"},
                 new Cities(){Id=3,Name="Delhi"}
            };
            List<States> States = new List<States>()
            {
                 new States(){Id=1,Name="Maharashtra"},
                 new States(){Id=2,Name="Karnataka"},
                 new States(){Id=3,Name="Tamil Nadu"}
            };
            vm.cities= citites.Select(a => new SelectListItem()
            {
                Text = a.Name,
                Value = a.Name.ToString()
            });
           vm.states = States.Select(a => new SelectListItem()
            {
                Text = a.Name,
                Value = a.Name.ToString()
            });

            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(StudentVM vm)
        {

            _db.Students.Add(vm.student);
            _db.SaveChanges();
            return RedirectToAction("Index");

            return View();
        }

        public  IActionResult Edit(int id)
        {

            var model =  _db.Students.FindAsync(id);

            if (model == null)
            {
                return NotFound(); 
            }
            return Ok(model);
        }
   
        public IActionResult Edited(StudentVM vm)
        {
            _db.Students.Update(vm.student);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _db.Students.Remove(_db.Students.Find(id));
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
