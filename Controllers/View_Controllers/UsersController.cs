using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;

namespace trekdle.Controllers.View_Controllers;

public class UsersController : Controller
{
    public IActionResult Log_In_Page()
    {
        return View();
    }
}