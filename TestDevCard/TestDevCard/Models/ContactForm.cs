using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace TestDevCard.Models
{
    public class ContactForm
    {
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Service { get; set; }
        public string Message { get; set; }
    }
}
