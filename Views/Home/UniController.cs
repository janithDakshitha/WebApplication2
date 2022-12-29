using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication2.Areas.Identity.Data;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Views.Home
{
    public class UniController : Controller
    {
        private readonly WebApplication2DbContext _webApplication2DbContext;
        private readonly UserManager<WebApplication2User> _userManager;
        private readonly SignInManager<WebApplication2User> _signInManager;
        public UniController(WebApplication2DbContext webApplication2DbContext, UserManager<WebApplication2User> userManager,
            SignInManager<WebApplication2User> signInManager)
        {
            _webApplication2DbContext = webApplication2DbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [Authorize]
        public async Task<IActionResult> Details ()
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (UserId == null || _webApplication2DbContext.Class == null)
            {
                return NotFound();
            }
            var Class = _webApplication2DbContext.Class.FirstOrDefault(m => m.UserId == UserId);
            if (Class == null)
            {
                //return NotFound();
                return View();
            }
            return View(Class);
        }
        public IActionResult Edit()
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (UserId == null /*|| UserId == 0*/)
            {
                return NotFound();
            }
            var classFromDb = _webApplication2DbContext.Class.Find(UserId);
            if (classFromDb == null)
            {
                return RedirectToAction("Create");
            }
            return View(classFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Class obj)
        {

            //if (ModelState.IsValid)
            //{
                _webApplication2DbContext.Class.Update(obj);
                _webApplication2DbContext.SaveChanges();
                return RedirectToAction("Details");
            //}
            //return View(obj);
        }
        public IActionResult Create()
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //ViewBag.userid = HttpContext.Session.GetString("Id");
            ViewBag.userid = UserId;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Class obj)
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //ViewBag.userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (UserId == null /*|| UserId == 0*/)
            {
                return NotFound();
            }
            var classFromDb = _webApplication2DbContext.Class.Find(UserId);
            if (classFromDb == null)
            {
                _webApplication2DbContext.Class.Add(obj);
                _webApplication2DbContext.SaveChanges();
            }
            return View(classFromDb);
        }
    }
}
