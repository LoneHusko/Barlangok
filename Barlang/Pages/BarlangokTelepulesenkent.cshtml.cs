using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Barlang.Pages
{
    public class BarlangokTelepulesenkent : PageModel
    {
        private readonly Barlang.Data.BarlangDbContext _context;

        public BarlangokTelepulesenkent(Barlang.Data.BarlangDbContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string KivalasztottTelepules { get; set; }

        public IList<string> Telepulesek { get; set; }
        
        public IList<Models.Barlang> Barlang { get;set; } = null;

        public async Task OnGetAsync()
        {
            Telepulesek = _context.Barlang.Select(x => x.Telepules).Distinct().ToList();
            Telepulesek.Add("");

            if (KivalasztottTelepules == "") {
                Barlang = await _context.Barlang.ToListAsync();
            }
            else {
                Barlang = await _context.Barlang.Where(x => x.Telepules == KivalasztottTelepules).ToListAsync();
            }
        }
    }
}