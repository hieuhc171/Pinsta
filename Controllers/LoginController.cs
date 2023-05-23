﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OurInstagram.Models;
using OurInstagram.Models.Login;
using OurInstagram.Models.Users;

namespace OurInstagram.Controllers;

public class LoginController : Controller
{
    public static User? user;
    private readonly ILogger<LoginController> _logger;

    public LoginController(ILogger<LoginController> logger)
    {
        _logger = logger;
    }
    
    public ActionResult Index()
    {
        // ModelState.Clear();
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public ActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public ActionResult Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            user = UserContext.GetCurrentUser(model.LoginInput.Email, model.LoginInput.Password);
            if (user != null) return RedirectToAction("Index", "Home");
            return NotFound("Không tồn tại user");
        }

        // ModelState.Clear();
        return View("Index", model);
    }

    [HttpPost]
    public ActionResult Signup(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            UserContext.CreateNewUser(model.SignupInput.Email, model.SignupInput.Password);
            return RedirectToAction("Index", "Home");
        }

        // ModelState.Clear();
        return View("Index", model);
    }
}