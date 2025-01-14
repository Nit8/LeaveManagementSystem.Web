using LeaveManagementSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var testModel = new TestViewModel { Name = "Test", Description = "This is a test model" };
            return View(testModel);
        }
    }
}
