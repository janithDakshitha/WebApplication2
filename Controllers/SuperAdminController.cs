using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Areas.Identity.Data;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class SuperAdminController : Controller
    {
        private readonly WebApplication2DbContext _webApplication2DbContext;
        private readonly UserManager<WebApplication2User> _userManager;
        private readonly SignInManager<WebApplication2User> _signInManager;
        private readonly IWebHostEnvironment webHostEnvironment; //get the access of service environment
        public SuperAdminController(WebApplication2DbContext webApplication2DbContext, UserManager<WebApplication2User> userManager,
            SignInManager<WebApplication2User> signInManager, IWebHostEnvironment webHost)
        {
            _webApplication2DbContext = webApplication2DbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            webHostEnvironment = webHost;
        }
        public IActionResult Index()
        {
            List<Class> Classes;//create a list of type uniprofilemodel and set that list to _context.Uniprofiles.Tolist
            Classes = _webApplication2DbContext.Class.ToList();
            return View(Classes);//then pass the list to the view to display on the screen 
        }
        public IActionResult Degree(string Id)
        {
            IEnumerable<degree> DegreeList = _webApplication2DbContext.degree.Where(c => c.UserId == Id).ToList();
            return View(DegreeList);
        }
    }
}
