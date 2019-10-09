using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FixtureApp.Data;
using FixtureApp.Repos;
using FixtureApp.Repos.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FixtureApp.Controllers
{
    public class MatchController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public MatchController(IUnitOfWork uow)
        {
            this.unitOfWork = uow as UnitOfWork;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(unitOfWork.MatchRepository.GetAll());
        }

        [HttpPost]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
            IEnumerable<Team> teams = unitOfWork.TeamRepository.GetAll();
            //int[] teams = new int[18];
            int numWeek = 17;

            object[] arrayTeam = new object[teams.Count()];

            int x = 0;
            foreach (var item in teams)
            {
                arrayTeam[x] = item;
                x++;
            }

            for (int i = 0; i < numWeek; i++)
            {
                var n = (teams.Count() - 1) / 2;
                for (int j = 0; j <= n; j++)
                {
                    Team teamA = arrayTeam[n - j] as Team;
                    Team teamB = arrayTeam[n + j + 1] as Team;
                    int dayOfWeek = (int)DateTime.Now.DayOfWeek;
                    DateTime nextSunday = DateTime.Now.AddDays(7*(i+1) - dayOfWeek).Date;
                    Match m = new Match { TeamLeft = teamA, TeamRight = teamB, MatchDate = nextSunday };

                    unitOfWork.MatchRepository.Add(m);

                    unitOfWork.Commit();
                }
                var temp = arrayTeam[1];
                for (int o = 1; o < arrayTeam.Length - 1; o++)
                {
                    arrayTeam[o] = arrayTeam[o + 1];
                }
                arrayTeam[arrayTeam.Length - 1] = temp;
            }
            return RedirectToAction("Index");
        }
    }
}
