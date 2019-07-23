using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ubrania_ASP.NET_Nowy.Data;
using Ubrania_ASP.NET_Nowy.Models;

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

        [HttpPost]
        public async Task<IActionResult> TakePrice(Cloth cloth, bool close)
        {


            if (cloth.Id == 0)
            {
                return NotFound();
            }

            var PC = await _context.Clothes.Where(c => c.Id == cloth.Id).SingleOrDefaultAsync();
            PC.PriceCounter = PC.Price + cloth.PriceCounter;

            PC.Sold = true;
            _context.SaveChanges();
            //if (close == true)
            //{
            //    _context.Update(PC);
            //}
            return View("Index", PC);

        }
    }
}