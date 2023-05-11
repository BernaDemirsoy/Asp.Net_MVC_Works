using VeriTransfer.Models;

namespace VeriTransfer.Data
{
    public static class DefaultData
    {
        private static int id = 1;
        private static List<Student> _students = new List<Student>
        {
            new Student (){Id = id , FirstName="Arda",LastName="Şen",Age=27}
        };
        public static List<Student> Students => _students;

        public static int Id => _students.Max(a=>a.Id)+1;
    }
}
