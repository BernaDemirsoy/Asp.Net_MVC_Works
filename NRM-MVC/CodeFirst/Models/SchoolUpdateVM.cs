using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{

    public class SchoolUpdateVM
    {
        [Required(ErrorMessage = "Id gönderir misin ey developer ! ")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Isımsız Okul olmaz arkadaş ! ")]
        [MinLength(2, ErrorMessage = "Duzgun girin son ikazım")]
        [StringLength(50, ErrorMessage = "Maksimum 50 karakter girebilirsiniz")]
        public string Name { get; set; }
    }
}
