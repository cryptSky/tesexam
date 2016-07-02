using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Data.Interfaces;
using Data.Entities;
using Hub.Interfaces;

namespace Tesexam.Controllers
{
    public class HomeController : Controller
    {
        private IQuizService _quizService;

        public HomeController(IQuizService quizCreator)
        {
            _quizService = quizCreator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> Db()
        {
            var quiz = HubTests.Fixtures.QuizFixture.QuizFixture_1();
            await _quizService.Create(quiz);

            var quizFromDB = await _quizService.Get(quiz.Id);

            return Json(quizFromDB);
        }
    }
}
