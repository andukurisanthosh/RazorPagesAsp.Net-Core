using System.ComponentModel.DataAnnotations;

namespace AbbyWeb.Model
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Display Order")]
        [Range(0, 100, ErrorMessage ="The Display range should be in range of 1-100.")]
        public int DisplayOrder { get; set; }
    }
}
