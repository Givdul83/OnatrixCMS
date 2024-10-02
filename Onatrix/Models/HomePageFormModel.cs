using MessagePack.Formatters;
using System.ComponentModel.DataAnnotations;

namespace Onatrix.Models
{
    public class HomePageFormModel
    {

        [Display(Name = "Name", Prompt = "Enter your name", Order = 0)]
        [Required(ErrorMessage = "You must enter a name")]
        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ\s-]{2,}$", ErrorMessage = "Invalid name, it must contain at least two characters")]
        public string Name { get; set; } = null!;

        [Display(Name = "Email address", Prompt = "Enter your email address", Order = 1)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Invalid Email address")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]{1,}@[a-zA-Z0-9.-]{2,}\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = null!;


        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number", Prompt = "Enter your phone number", Order = 2)]
        [Required(ErrorMessage = "You must enter a phone number")]
        [RegularExpression(@"^\+?\d{1,3}?[-\s]?\d{7,14}$", ErrorMessage = "Invalid phone number")]
        public string Phone {  get; set; } = null!;

    }
}
