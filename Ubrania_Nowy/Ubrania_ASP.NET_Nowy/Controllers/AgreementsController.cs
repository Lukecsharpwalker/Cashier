using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ubrania_ASP.NET_Nowy.Data;
using Ubrania_ASP.NET_Nowy.Models;

namespace Ubrania_ASP.NET_Nowy.Controllers
{
    public class AgreementsController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        public int? pass_id;

        public AgreementsController(
            ApplicationDbContext context,
             UserManager<ApplicationUser> userManager,
             ILogger<AccountController> logger,
             SignInManager<ApplicationUser> signInManager
            )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
            _logger = logger;
        }

        // GET: Agreements
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agreements.ToListAsync());
        }

        // GET: Agreements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agreement = await _context.Agreements
                .SingleOrDefaultAsync(m => m.Id == id);
            var cloth = await _context.Clothes.Where(m => m.Agreement_Id == id)
                .ToListAsync();
            if (agreement == null)

            {
                return NotFound();
            }
            return View(agreement);

        }

        // GET: Agreements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agreements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("Id,Name,Surname,Tel,Pesel,Begin,End")] */Agreement agreement/*, string returnUrl = null*/)
        {
            //ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                _context.Add(agreement);
                await _context.SaveChangesAsync();
                



                var user = new ApplicationUser
                {
                    UserName = agreement.Id.ToString(),
                    Agreement_Id = agreement.Id.ToString(),
                };
                /*var result =*/ await _userManager.CreateAsync(user, agreement.Pesel.ToString());
                //if (result.Succeeded)
                //{
                //    _logger.LogInformation("User created a new account with password.");

                //    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //    var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                //    //await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                //    await _signInManager.SignInAsync(user, isPersistent: false);
                //    _logger.LogInformation("User created a new account with password.");
                //   // return RedirectToAction(nameof(Index));
                //    return RedirectToLocal(returnUrl);
                //}
                return RedirectToAction(nameof(Index));
            }

            return View(agreement);
        }

        // GET: Agreements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agreement = await _context.Agreements.SingleOrDefaultAsync(m => m.Id == id);
            if (agreement == null)
            {
                return NotFound();
            }
            return View(agreement);
        }

        // POST: Agreements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, /*[Bind("Id,Name,Surname,Tel,Pesel,Begin,End")]*/ Agreement agreement)
        {
            if (id != agreement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agreement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgreementExists(agreement.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(agreement);
        }

        // GET: Agreements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            

            var agreement = await _context.Agreements
                .SingleOrDefaultAsync(m => m.Id == id);
            if (agreement == null)
            {
                return NotFound();
            }

            return View(agreement);
        }

        // POST: Agreements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agreement = await _context.Agreements.SingleOrDefaultAsync(m => m.Id == id);
            _context.Agreements.Remove(agreement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
      //  [HttpPost, ActionName("GoToClothes")]
     //   [ValidateAntiForgeryToken]
        public async Task<IActionResult> GoToClothes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
          //  var cloth = await _context.Clothes.Where(m => m.Agreement_Id == id).ToListAsync();
            

            TempData["data1"] = id.ToString();
            return RedirectToAction("Create_Cloth");
          //  return View(cloth);
           

        }

        public IActionResult Create_Cloth()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create_Cloth(/*[Bind("Id,Name,Surname,Tel,Pesel,Begin,End")] */Cloth cloth)
        {
            string str;
            str = TempData["data1"].ToString();

            if (ModelState.IsValid)
            {
                cloth.Agreement_Id =Convert.ToInt32(str); 
                _context.Add(cloth);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create_Cloth));
            }
            return View(cloth);
        }




        //public IActionResult Create_Cloth()
        //{
        //    ViewData["Agreement_Id"] = new SelectList(_context.Agreements, "Id", "Name");
        //    return View();
        //}

        //// POST: Clothes/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create_Cloth([Bind("Id,Mark,Size,Colour,Type,Description,Price,Price_RL,Agreement_Id,Sold")] Cloth cloth)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(cloth);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(GoToClothes));
        //    }
        //    ViewData["Agreement_Id"] = new SelectList(_context.Agreements, "Id", "Name", cloth.Agreement_Id);
        //    return View(cloth);
        //}


        public async Task<IActionResult> AgreementClothes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
              var cloth = await _context.Clothes.Where(m => m.Agreement_Id == id).ToListAsync();


              return View(cloth);


        }




        private bool AgreementExists(int id)
        {
            return _context.Agreements.Any(e => e.Id == id);
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
