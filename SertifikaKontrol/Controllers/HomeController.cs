﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using SertifikaKontrol.Models;

namespace SertifikaKontrol.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.IsLoggedIn = HttpContext.Session.GetString("IsLoggedIn") == "true";  //Oturumun bu sayfada da açık kalması için

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
