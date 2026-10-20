using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoltsegvetesWebApp.Models;
using KoltsegvetesWebApp.Data;

namespace KoltsegvetesWebApp.Pages.TranzakcioPages;

public class IndexModel : PageModel
{
    private readonly KoltsegvetesDbContext _context;

    public IndexModel(KoltsegvetesDbContext context)
    {
        _context = context;
    }

    public IList<Tranzakcio> Tranzakcio { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Tranzakcio = await _context.Tranzakciok.ToListAsync();
    }
}
