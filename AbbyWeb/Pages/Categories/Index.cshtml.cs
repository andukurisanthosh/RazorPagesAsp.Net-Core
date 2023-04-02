using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace AbbyWeb.Pages.Categories
{
    [Authorize]

    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IEnumerable<Category> Categories { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
            
        }
        
        public void OnGet()
        {
            Categories= _context.Categories;
        }
    }
}
