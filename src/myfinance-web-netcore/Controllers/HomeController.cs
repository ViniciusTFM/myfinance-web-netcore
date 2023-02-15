using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    // GET: Home/Create
    public IActionResult Create()
    {
        ViewBag.Title = "Create";
        return View();
    }

    // POST: Home/Create
    [HttpPost]
    public IActionResult Create(string name)
    {
        try
        {
            //Method 1: Using Component Name

            /*
            ViewData["City"] = collection["City"];
            ViewData["Address"] = collection["Address"];*/

            //Method 2: Using Component Index Position
            //ViewData["Name"] = collection[1];
            //ViewData["City"] = collection[2];
            //ViewData["Address"] = collection[3];

            return Content($"Email recebido : {name}");
        }
        catch
        {
            return View();
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }
}
