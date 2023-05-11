using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models.ModelMetaDataTypes
{
    public class SchoolCreateVMMetaData
    {
        [Required(ErrorMessage = "Isımsız Okul olmaz arkadaş ! ")]
        [MinLength(2, ErrorMessage = "Duzgun girin son ikazım")]
        [StringLength(50, ErrorMessage = "Maksimum 50 karakter girebilirsiniz")]
        public string Name { get; set; }
        //[RegularExpression(@"^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[^\w\d\s:])([^\s]){8,16}$", ErrorMessage = "Must contain 1 number (0-9), 1 uppercase letter, 1 lowercase letter, 1 non - alpha numeric number, 8 - 16 characters with no space")]
        //public string Password { get; set; }
    }
}
