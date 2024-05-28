using Microsoft.AspNetCore.Mvc;
using ML.Models.VideoSetup;

namespace ML.Controllers
{
    public class LeaugeController : Controller
    {
        public IActionResult Leauge()
        {
            var videos = new List<VideoModel>();

            // Path to the directory containing the Leauge videos
            var videoDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "videos", "Leauge");

            // Get all .mp4 files in the Leauge directory
            var videoFiles = Directory.GetFiles(videoDirectory, "*.mp4");

            foreach (var videoFile in videoFiles)
            {
                var title = Path.GetFileNameWithoutExtension(videoFile);
                var relativePath = Path.GetRelativePath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), videoFile);
                var url = Url.Content("~/") + relativePath.Replace("\\", "/");

                videos.Add(new VideoModel { Title = title, Url = url });
            }

            return View(videos);
        }

        // Other Leauge controller actions
    }
}