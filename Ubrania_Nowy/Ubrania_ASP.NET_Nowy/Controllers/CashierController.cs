using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ubrania_ASP.NET_Nowy.Data;

namespace Ubrania_ASP.NET_Nowy.Controllers
{
    public class CashierController : Controller

      

    {
        private readonly ApplicationDbContext _context;
        public CashierController(
               ApplicationDbContext context
               )
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TakePrice(int? Id)
        {
            

            if (Id == null)
            {
                return NotFound();
            }

            
            var clothPrice = await _context.Clothes.Where(c => c.Id == Id).ToListAsync();

            return View(clothPrice);

        }
    }
}