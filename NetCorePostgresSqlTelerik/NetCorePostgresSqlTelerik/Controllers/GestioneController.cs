using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCorePostgresSqlTelerik.Data;

namespace NetCorePostgresSqlTelerik.Controllers
{
    [Authorize]
    public class GestioneController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GestioneController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
