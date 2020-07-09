using System.ComponentModel.DataAnnotations;

namespace Chapter13RazorViews.ViewModels
{
    public class AddEventCategoryViewModel
    {
        [Required(ErrorMessage = "Category Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Category Name must be between 3 and 50 characters.")]
        public string Name { get; set; }


    }
}
