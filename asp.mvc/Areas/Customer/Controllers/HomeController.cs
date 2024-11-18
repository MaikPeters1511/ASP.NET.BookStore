using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using asp.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp.mvc.Areas.Customer.Controllers;

[Area("Customer")]
public class HomeController(ILogger<HomeController> logger) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;
    public IActionResult Index() => View();
    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}