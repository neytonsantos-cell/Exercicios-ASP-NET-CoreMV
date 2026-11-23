using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Exercicios_ASP_NET_CoreMVC.Models;

namespace Exercicios_ASP_NET_CoreMVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["Mensagem"] = "Bem Vindo ao nosso site";
        return View();
    }   
}
