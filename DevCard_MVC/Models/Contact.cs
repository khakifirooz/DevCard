using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Serialization;

namespace DevCard_MVC.Models
{
    public class Contact
    {
        [Required(ErrorMessage ="این فیلد اجباری است")]
        [MinLength(3,ErrorMessage ="حداقل اسم باید سه حرفی باشد")]
        [MaxLength(20,ErrorMessage = "حداکثر اسم باید 20 حرفی باشد")]
        public string Name { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [EmailAddress(ErrorMessage ="مقدار وراد شده ایمیل صحیح نمیباشد")]
        public string Email { get; set; }
        public int? Service { get; set; }
        public string Message { get; set; }

        [ValidateNever]
        public SelectList Services { get; set; }
    }
}
