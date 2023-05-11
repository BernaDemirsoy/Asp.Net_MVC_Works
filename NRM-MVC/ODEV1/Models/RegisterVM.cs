namespace ODEV1.Models
{
    public class RegisterVM
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
    }
}
