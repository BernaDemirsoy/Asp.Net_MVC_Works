using CodeFirst.Models.ModelMetaDataTypes;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    [ModelMetadataType(typeof(SchoolCreateVMMetaData))]
    public class SchoolCreateVM
    {
        //[Required(ErrorMessage ="Isımsız Okul olmaz arkadaş ! ") ]
        //[MinLength(2,ErrorMessage ="Duzgun girin son ikazım")]
        //[StringLength(50,ErrorMessage = "Maksimum 50 karakter girebilirsiniz")]
        public string Name { get; set; }
    }
}
