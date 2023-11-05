using CodeLife.web.Data;
using CodeLife.web.Models.Domain;
using CodeLife.web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodeLife.web.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly CodeLifeDbContext _context;
        public AdminTagsController(CodeLifeDbContext codeLifeDbContext)
        {
                _context = codeLifeDbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName,
            };
            _context.Tags.Add(tag);
            _context.SaveChanges();
            return View("Add");
        }

        [HttpGet]
        public IActionResult List()
        {
            var tags = _context.Tags.ToList();
            return View(tags);
        }
    }
}
