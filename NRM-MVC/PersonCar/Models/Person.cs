namespace PersonCar.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Car> Cars { get; set; }
        public Person()
        {
            Cars = new List<Car>();
        }
    }
}
