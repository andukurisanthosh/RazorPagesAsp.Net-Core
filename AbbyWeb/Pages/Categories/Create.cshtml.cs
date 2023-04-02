using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public Category Category { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(Category.FirstName == Category.DisplayOrder.ToString()) {
                ModelState.AddModelError("Category.FirstName", "The first name can not be same as Last name");
            }
            if (ModelState.IsValid)
            {
                await _context.Categories.AddAsync(Category);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Category created Sucessfully";
                return RedirectToPage("Index");
            }
            return Page();
            
        }
    }
}
