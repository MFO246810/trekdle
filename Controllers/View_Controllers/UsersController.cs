using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using trekdle.Models.DB_Models;
using trekdle.DB_Context;
using trekdle.Services;

namespace trekdle.Controllers.View_Controllers;

public class UsersController : Controller
{
    private readonly Admin_Service _adminService;
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Add_User()
    {
        return View();
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create_User(Admin User_Data){   
        try{
            if (User_Data == null){
                return BadRequest("User data cannot be null.");
            }

            if (!ModelState.IsValid){
                return View(User_Data); 
            }

            await _adminService.CreateItemAsync(User_Data);

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error creating user: {ex}");
            return StatusCode(500, "An error occurred while processing your request.");
        }

    }
    
}