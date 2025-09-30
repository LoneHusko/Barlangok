using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Barlang.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Barlang.Data.BarlangDbContext _context;

        public IndexModel(Barlang.Data.BarlangDbContext context)
        {
            _context = context;
        }

        public IList<Models.Barlang> Barlang { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Barlang = await _context.Barlang.ToListAsync();
        }
    }
}
