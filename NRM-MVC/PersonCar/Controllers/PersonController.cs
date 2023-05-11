using Microsoft.AspNetCore.Mvc;
using PersonCar.Models;

namespace PersonCar.Controllers
{
    public class PersonController : Controller
    {
        private Person person;
        public PersonController()
        {
            person = new Person()
            {
                FirstName = "Muhammet",
                LastName = "Güler"
            };
            List<Car> cars = new List<Car>()
            {
                new Car{Id=2010,Brand="Tofaş",Person=person},
                 new Car{Id=2015,Brand="BMW",Person=person},
                 new Car{Id=2013,Brand="Audi",Person=person},
            };
            person.Cars= cars;
        }
        public IActionResult Index()
        {
            return View(person);
        }
        public IActionResult PersonsCar()
        {
            return View(person.Cars);
        }
    }
}
