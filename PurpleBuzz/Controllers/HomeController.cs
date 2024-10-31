using Microsoft.AspNetCore.Mvc;
using PurpleBuzz.DataBase;
using PurpleBuzz.Models.About;
using PurpleBuzz.Models.Home;

namespace PurpleBuzz.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDBContext _appDBContext;
        public HomeController(AppDBContext context)
        {
            _appDBContext = context;
        }
        public IActionResult Index()
        {
            var Works = _appDBContext.Works.ToList();
            var workList = new List<WorkVM>();
            foreach (var work in Works)
            {
                var WorkVM = new WorkVM
                {
                    Name = work.Name,
                    ImgSrc = work.ImgSrc,
                    Description = work.Description
                };
                workList.Add(WorkVM);
            }
            var model = new HomeIndexVM
            {
                Works = workList
            };
            return View(model);
        }
    }
}
