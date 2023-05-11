using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{

    public class LessonCreateVM
    {
        [StringLength(10,ErrorMessage ="Isim uzunluğu maksimum 10 karakter olabilir")]
        [Required(ErrorMessage ="Isim girişi zorunlu")]
        public string Name { get; set; }
    }
}
