using Microsoft.AspNetCore.Mvc;

namespace ML.Controllers
{
    public class VideoController : Controller
    {
        public IActionResult Watch(string videoUrl)
        {
            // Pass the video URL to the view
            return View("Watch", videoUrl);
        }
    }
}
