using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ML.Models;
using ML.Models.VideoSetup;

namespace ML.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Introduction(){
        return View();
    }

    public IActionResult Index()
    {
        var videos = new List<VideoModel>();

        // Path to the directory containing the videos
        var videoDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "videos");

        // Get all .mp4 files in the directory
        var videoFiles = Directory.GetFiles(videoDirectory, "*.mp4", SearchOption.AllDirectories);

        foreach (var videoFile in videoFiles)
        {
            var title = Path.GetFileNameWithoutExtension(videoFile);
            var relativePath = Path.GetRelativePath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), videoFile);
            var url = Url.Content("~/") + relativePath.Replace("\\", "/");

            videos.Add(new VideoModel { Title = title, Url = url });
        }

        return View(videos);
    }

    public IActionResult Video(string title, string url){

        // Pass the title and URL parameters to the Video.cshtml view
        ViewBag.Title = title;
        ViewBag.Url = url;

        return View("~/Views/Video/Video.cshtml");

    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}