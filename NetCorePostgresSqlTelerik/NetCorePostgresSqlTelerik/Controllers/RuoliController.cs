using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCorePostgresSqlTelerik.Data;

namespace NetCorePostgresSqlTelerik.Controllers
{
    public class RuoliController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public RuoliController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                ICollection<IdentityRole> ruoli = new List<IdentityRole>();

                if (_signInManager.IsSignedIn(User))
                    ruoli = _context.Roles.ToList();


                return Json(ruoli.ToDataSourceResult(request));
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore: " + e.Message);

                return Json("");

                // TO DO: scrivere codice per inserire errore in una tabella
            }
        }

        public ActionResult Create([DataSourceRequest] DataSourceRequest request, IdentityRole nuovoR)
        {
            try
            {
                if(nuovoR != null)
                {
                    _context.Add(nuovoR);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore: " + e.Message);

                // TO DO: scrivere codice per inserire errore in una tabella
            }

            return Json(nuovoR);
        }
        [AcceptVerbs("Post")]

        public ActionResult Update([DataSourceRequest] DataSourceRequest request, IdentityRole ruolo)
        {
            try
            {
                if (ruolo != null)
                {
                    _context.Update(ruolo);
                    _context.SaveChanges();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Errore: " + e.Message);

                // TO DO: scrivere codice per inserire errore in una tabella
            }

            return Json(ruolo);
        }
        [AcceptVerbs("Post")]

        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, IdentityRole ruolo)
        {
            try
            {
                if(ruolo != null)
                {
                    _context.Remove(ruolo);
                    _context.SaveChanges();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Errore: " + e.Message);

                // TO DO: scrivere codice per inserire errore in una tabella
            }
            return Json(ruolo);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
