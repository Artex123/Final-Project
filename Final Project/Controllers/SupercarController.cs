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
    }
}
