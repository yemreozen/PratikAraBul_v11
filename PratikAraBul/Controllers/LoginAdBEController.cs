using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PratikAraBul.Controllers
{
    [AllowAnonymous]
    public class LoginAdBEController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        
        public async Task<IActionResult>Index(Writer p)
        {
            Context c = new Context();

            var dataValue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail &&
            x.WriterPassword == p.WriterPassword);

            if (dataValue!=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.WriterMail)
                };
                var useridentity= new ClaimsIdentity(claims,"a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("bloglistwithwriter", "blog");   
            }
            else
            {
                ModelState.AddModelError("Error", "Kullanıcı adı veya şifre yanlış");
                return View();
            }

       
        }
        public async Task<IActionResult> Logout()
        {
            // Kullanıcıyı oturumdan çıkart
            await HttpContext.SignOutAsync();

            // Oturumu sonlandırdıktan sonra yönlendirilecek sayfayı belirle (örneğin Ana Sayfa'ya yönlendir)
            return RedirectToAction("Index", "LoginAdBE");
        }
    }
}
