using Microsoft.AspNetCore.Mvc;
using DotnetPlayground.Models;
using DotnetPlayground.ViewModels;
using DotnetPlayground.Data;
using System.Linq;

namespace DotnetPlayground.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new TaskListViewModel
            {
                Tasks = _context.TaskItems.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddTask(TaskListViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.TaskItems.Add(viewModel.NewTask);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteTask(int id)
        {
            var task = _context.TaskItems.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _context.TaskItems.Remove(task);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ToggleComplete(int id)
        {
            var task = _context.TaskItems.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsComplete = !task.IsComplete;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
