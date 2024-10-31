using Microsoft.AspNetCore.Mvc;
using PurpleBuzz.DataBase;
using PurpleBuzz.Models.About;

namespace PurpleBuzz.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDBContext _appDBContext;
        public AboutController(AppDBContext context)
        {
            _appDBContext = context;
        }
        public IActionResult Index()
        {
            var teamMembers = _appDBContext.TeamMembers.ToList();
            var teamMembersList = new List<TeamMembersVM>();
            foreach (var teamMember in teamMembers)
            {
                var teamMemberVM = new TeamMembersVM
                {
                    Name = teamMember.Name,
                    Surname = teamMember.Surname,
                    ImgSrc = teamMember.ImgSrc,
                    Position = teamMember.Position
                };
                teamMembersList.Add(teamMemberVM);
            }

            var Aims = _appDBContext.Aims.ToList();
            var AimsList = new List<AimsVM>();
            foreach (var Aim in Aims)
            {
                var aimVM = new AimsVM
                {
                    Description = Aim.Description,
                    IconName = Aim.IconName,
                    Name = Aim.Name
                };
                AimsList.Add(aimVM);
            }
            var model = new AboutIndexVM
            {
                TeamMembers = teamMembersList,
                Aims = AimsList
            };
            return View(model);
        }
    }
}
