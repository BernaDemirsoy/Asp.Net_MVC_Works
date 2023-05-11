using System.ComponentModel.DataAnnotations;

namespace Ajax.Models
{
    public class Person
    {
        public int Id { get; set; }
        [StringLength(4,ErrorMessage ="4 haneden fazla girilemez")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
