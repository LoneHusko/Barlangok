using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Barlang.Data;
using Barlang.Models;

namespace Barlang.Pages.Barlangok
{
    public class DeleteModel : PageModel
    {
        private readonly Barlang.Data.BarlangDbContext _context;

        public DeleteModel(Barlang.Data.BarlangDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Barlang Barlang { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barlang = await _context.Barlang.FirstOrDefaultAsync(m => m.ID == id);

            if (barlang == null)
            {
                return NotFound();
            }
            else
            {
                Barlang = barlang;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barlang = await _context.Barlang.FindAsync(id);
            if (barlang != null)
            {
                Barlang = barlang;
                _context.Barlang.Remove(Barlang);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
