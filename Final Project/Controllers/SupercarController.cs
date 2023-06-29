using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    public class SupercarController : Controller
    {
        private readonly ISupercarRepository _car;
        public SupercarController(ISupercarRepository car)
        {
            _car = car;
        }
        public IActionResult Index()
        {
            var supercars = _car.GetAllSupercars();
            return View(supercars);
        }

        public IActionResult ViewSupercar(int id)
        {
            var supercar = _car.GetSupercar(id);
            return View(supercar);
        }

        public IActionResult UpdateSupercar(int id)
        {
            Supercar supe = _car.GetSupercar(id);
            if (supe == null)
            {
                return View("SupercarNotFound");
            }
            return View(supe);
        }
        public IActionResult UpdateSupercarToDatabase(Supercar supercar)
        {
            _car.UpdateSupercar(supercar);

            return RedirectToAction("ViewSupercar", new { id = supercar.Id });
        }

        public IActionResult AddSupercar(Supercar supercarToAdd)
        {
            if (supercarToAdd == null)
            {
                return View("SupercarNotFound");
            }
            return View(supercarToAdd);
        }
        public IActionResult AddSupercarToDatabase(Supercar supercar)
        {
            _car.AddSupercar(supercar);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSupercar(Supercar supercar)
        {
            if (supercar == null)
            {
                return View("SupercarNotFound");
            }
            _car.RemoveSupercar(supercar);
            return RedirectToAction("Index");
        }
    }
}
