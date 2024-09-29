using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TravelEngin.ViewModels;

namespace TravelEngin.Controllers;

public class TravelController : Controller
{
    private readonly ILogger<TravelController> _logger;

    public TravelController(ILogger<TravelController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }


    public IActionResult AboutUs()
    {
        return View();
    }

    public IActionResult ContactUs()
    {
        return View();
    }

    public IActionResult KnowledgeBase()
    {
        return View();
    }

    public IActionResult Terms()
    {
        return View();
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
