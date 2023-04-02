using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
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
            var CategoryFromDb = _context.Categories.Find(Category.id);
            if (CategoryFromDb != null)
            {
                _context.Categories.Remove(CategoryFromDb);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Category deleted Sucessfully";
                return RedirectToPage("Index");
            }     
        
            return Page();

        }
    }
}
