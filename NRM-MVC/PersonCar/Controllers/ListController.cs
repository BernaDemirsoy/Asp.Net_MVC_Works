using Microsoft.AspNetCore.Mvc;
using PersonCar.Models;

namespace PersonCar.Controllers
{
    public class ListController : Controller
    {
        private List<Person> people;
        public ListController()
        {
            people = new List<Person>()
            {
                new Person(){Id = 1,FirstName = "Arda",LastName = "Şen"},
                new Person(){Id = 2,FirstName = "Atakan",LastName = "Kelle"},
                new Person(){Id = 3,FirstName = "Furkan",LastName = "Bayar"},
                new Person(){Id = 4,FirstName = "Muhammed Çağrı",LastName = "Buhurcu"},
                new Person(){Id = 5,FirstName = "Nadire",LastName = "Çobanoğlu"},
            };
            List<Car> ardasCar = new List<Car>()
            {
                new Car(){Id = 1,Brand="Golf", Person=people[0]},
                new Car(){Id = 2,Brand="BMW", Person=people[0]}, }
            ;
            people[0].Cars = ardasCar;

            List<Car> atakansCar = new List<Car>()
            {
                new Car(){Id = 3,Brand="Polo", Person=people[1]},
                new Car(){Id = 4,Brand="Mercedes", Person=people[1]}, }
            ;
            people[1].Cars = atakansCar;

            List<Car> furkansCar = new List<Car>()
            {
                new Car(){Id = 5,Brand="Passat", Person=people[2]},
                new Car(){Id = 6,Brand="Audi", Person=people[2]}, }
            ;
            people[2].Cars = furkansCar;

            List<Car> cagrisCar = new List<Car>()
            {
                new Car(){Id = 7,Brand="Troc", Person=people[3]},
                new Car(){Id = 8,Brand="Volvo", Person=people[3]}, }
            ;
            people[3].Cars = cagrisCar;

            List<Car> nadiresCar = new List<Car>()
            {
                new Car(){Id = 9,Brand="Tiguan", Person=people[4]},
                new Car(){Id = 10,Brand="Micra", Person=people[4]}, }
            ;
            people[4].Cars = nadiresCar;
        }
        public IActionResult Index()
        {
            ViewBag.People=people;
            return View();
        }
        public IActionResult GetCars(int id)
        {
            List<Car> carList = people.Where(a => a.Id == id).FirstOrDefault().Cars;
            return View(carList);
        }
    }
}
