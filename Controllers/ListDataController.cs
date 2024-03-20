using Microsoft.AspNetCore.Mvc;
using ToDoList2.Data;
using ToDoList2.Models;

namespace ToDoList2.Controllers
{
    public class ListDataController : Controller
    {
        AppllicationDbContext context = new AppllicationDbContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Name(string Name)
        {
            ViewData["Name"] = Name;
            var items = context.ListItems.ToList();
            return View(items);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateNew(ListItem item)
        {
            var ListOfItems = context.ListItems
                .Add(new ListItem{Title=item.Title,Description=item.Description,Deadline=item.Deadline});
            context.SaveChanges();
            return RedirectToAction("Name");
        }
        public IActionResult Edit(int id)
        {
            var edit = context.ListItems.First(x => x.Id == id);
            return View(edit);
        }
        public IActionResult Editdata(ListItem item)
        {
            var list = context.ListItems.First(e=>e.Id == item.Id);
            list.Title = item.Title;
            list.Description = item.Description;
            list.Deadline = item.Deadline;
            context.SaveChanges();
            return RedirectToAction("Name");
        }
        public IActionResult Delete(int id)
        {
            var delete = context.ListItems.First(x => x.Id == id);
            context.Remove(delete);
            context.SaveChanges();
            return RedirectToAction ("Name");
        }
    }
}
