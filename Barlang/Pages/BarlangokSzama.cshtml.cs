using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Barlang.Pages
{
    public class BarlangokSzama : PageModel
    {
        private readonly Barlang.Data.BarlangDbContext _context;

        public BarlangokSzama(Barlang.Data.BarlangDbContext context)
        {
            _context = context;
        }

        public IList<TelepulesStat> BarlangokTelepulesenként { get; set; }

        public async Task OnGetAsync() {
            BarlangokTelepulesenként = await _context.Barlang
                .GroupBy(b => b.Telepules)
                .Select(g => new TelepulesStat
                {
                    Telepules = g.Key,
                    Darab = g.Count()
                })
                .OrderBy(x => x.Telepules)
                .ToListAsync();
        }
    }

    public class TelepulesStat
    {
        public string Telepules { get; set; }
        public int Darab { get; set; }
    }
}