using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public Category Category { get; set; }
        public void OnGet(int id)
        {
            Category = _context.Categories.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (Category.FirstName == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.FirstName", "The first name can not be same as Last name");
            }
            if (ModelState.IsValid)
            {
                _context.Categories.Update(Category);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Category updated Sucessfully";
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}
