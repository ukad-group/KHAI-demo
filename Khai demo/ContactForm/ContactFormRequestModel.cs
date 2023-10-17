using System.ComponentModel.DataAnnotations;

namespace Khai_demo.ContactForm
{
    public class ContactFormRequestModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Telegram { get; set; }
        [Required]
        public string Question { get; set; }
    }
}
