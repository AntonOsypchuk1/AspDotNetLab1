using Microsoft.AspNetCore.Mvc;

namespace AspDotNetLab1.controller
{
    public class ErrorController : Controller
    {
        [Route("/Error")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return RedirectToAction("PageNotFound");
                default:
                    return RedirectToAction("Index");
            }
        }

        [Route("/Error/PageNotFound")]
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}
