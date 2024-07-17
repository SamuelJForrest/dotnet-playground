using Microsoft.AspNetCore.Mvc;
using DotnetPlayground.Models;
using DotnetPlayground.ViewModels;
using DotnetPlayground.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DotnetPlayground.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchString)
        {
            IQueryable<TaskItem> tasksQuery = _context.TaskItems;

            if (!String.IsNullOrEmpty(searchString))
            {
                tasksQuery = tasksQuery.Where(t => t.Description.Contains(searchString));
            }

            var viewModel = new TaskListViewModel
            {
                Tasks = tasksQuery.OrderBy(t => t.IsComplete).ToList(),
                SearchString = searchString
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

        public async Task<IActionResult> EditTask(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.TaskItems.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
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
