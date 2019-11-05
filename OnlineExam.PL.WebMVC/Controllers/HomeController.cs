using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineExam.BLL.Concrete;
using OnlineExam.PL.WebMVC.Models;
using OnlineExam.Model;
using HtmlAgilityPack;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
 
namespace OnlineExam.PL.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        #region Services
        readonly UserService userService;
        readonly ExamService examService;
        readonly QuestionService questionService;
        readonly ChoiceService choiceService;
        #endregion

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            userService = new UserService();
            examService = new ExamService();
            questionService = new QuestionService();
            choiceService = new ChoiceService();

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(IFormCollection frm)
        {
            User user = userService.GetByMailAndPassword(frm["txtUserName"], frm["txtPassword"]);

            if (user != null)
                return RedirectToAction("FormExam", "Home");
            else
            {
                ModelState.AddModelError("", "Invalid e-mail or password");
                return View("Index", "Login");
            }


            
        }

        public IActionResult FormExam()
        {
            #region DataFromWiredcom
            HtmlWeb website = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.Default
            };
            HtmlDocument Doc = website.Load("https://www.wired.com/most-recent/");
            var h2 = Doc.DocumentNode.Descendants("h2").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("archive-item-component__title")).Take(5).ToList();
            var p = Doc.DocumentNode.Descendants("p").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("archive-item-component__desc")).Take(5).ToList();
            #endregion

            #region SelectListItem
            List<SelectListItem> myh2 = new List<SelectListItem>() {
                new SelectListItem {
            Text = h2[0].InnerHtml, Value = p[0].InnerHtml},
                new SelectListItem {
            Text = h2[1].InnerHtml, Value = p[1].InnerHtml},
                new SelectListItem {
            Text = h2[2].InnerHtml, Value = p[2].InnerHtml},
                new SelectListItem {
            Text = h2[3].InnerHtml, Value = p[3].InnerHtml},
                new SelectListItem {
            Text = h2[4].InnerText, Value = p[4].InnerHtml}
            };
            #endregion

            #region ViewDatas
            ViewData["h2"] = myh2;
            ViewData["p0"] = p[0].InnerHtml;
            ViewData["p1"] = p[1].InnerHtml;
            ViewData["p2"] = p[2].InnerHtml;
            ViewData["p3"] = p[3].InnerHtml;
            ViewData["p4"] = p[4].InnerHtml;
            #endregion

            return View();
        }

        [HttpPost]
        public IActionResult FormExam(IFormCollection frm)
        {
           
            Exam exam = new Exam { ExamName = frm["hidden"], CreatedDate = DateTime.Now, ExamText = frm["h2"], UserID = 1, IsActive = true };
            examService.Add(exam);

            #region Questions
            Question q1 = new Question { QuestionText = frm["question1"], ExamID = exam.ExamID };
            Question q2 = new Question { QuestionText = frm["question2"], ExamID = exam.ExamID };
            Question q3 = new Question { QuestionText = frm["question3"], ExamID = exam.ExamID };
            Question q4 = new Question { QuestionText = frm["question4"], ExamID = exam.ExamID };
            questionService.Add(q1);
            questionService.Add(q2);
            questionService.Add(q3);
            questionService.Add(q4);
            #endregion

            #region Choices
            Choice c1 = new Choice { ChoiceText = frm["q1a"], QuestionID = q1.QuestionID };
            Choice c2 = new Choice { ChoiceText = frm["q1b"], QuestionID = q1.QuestionID };
            Choice c3 = new Choice { ChoiceText = frm["q1c"], QuestionID = q1.QuestionID };
            Choice c4 = new Choice { ChoiceText = frm["q1d"], QuestionID = q1.QuestionID };
            if (frm["correct"] == "1") { c1.IsCorrect = true; }
            else if (frm["correct"] == "2") { c2.IsCorrect = true; }
            else if (frm["correct"] == "3") { c3.IsCorrect = true; }
            else c4.IsCorrect = true;
           

            Choice c5 = new Choice { ChoiceText = frm["q2a"], QuestionID = q2.QuestionID };
            Choice c6 = new Choice { ChoiceText = frm["q2b"], QuestionID = q2.QuestionID };
            Choice c7 = new Choice { ChoiceText = frm["q2c"], QuestionID = q2.QuestionID };
            Choice c8 = new Choice { ChoiceText = frm["q2d"], QuestionID = q2.QuestionID };
            if (frm["correct1"] == "1") { c5.IsCorrect = true; }
            else if (frm["correct1"] == "2") { c6.IsCorrect = true; }
            else if (frm["correct1"] == "3") {c7.IsCorrect = true; }
            else c8.IsCorrect = true;

            Choice c9 = new Choice { ChoiceText = frm["q3a"], QuestionID = q3.QuestionID };
            Choice c10 = new Choice { ChoiceText = frm["q3b"], QuestionID = q3.QuestionID };
            Choice c11 = new Choice { ChoiceText = frm["q3c"], QuestionID = q3.QuestionID };
            Choice c12 = new Choice { ChoiceText = frm["q3d"], QuestionID = q3.QuestionID };
            if (frm["correct2"] == "1") { c9.IsCorrect = true; }
            else if (frm["correct2"] == "2") { c10.IsCorrect = true; }
            else if (frm["correct2"] == "3") { c11.IsCorrect = true; }
            else c12.IsCorrect = true;

            Choice c13 = new Choice { ChoiceText = frm["q4a"], QuestionID = q4.QuestionID };
            Choice c14 = new Choice { ChoiceText = frm["q4b"], QuestionID = q4.QuestionID };
            Choice c15 = new Choice { ChoiceText = frm["q4c"], QuestionID = q4.QuestionID };
            Choice c16 = new Choice { ChoiceText = frm["q4d"], QuestionID = q4.QuestionID };
            if (frm["correct3"] == "1") { c13.IsCorrect = true; }
            else if (frm["correct3"] == "2") { c14.IsCorrect = true; }
            else if (frm["correct3"] == "3") { c15.IsCorrect = true; }
            else c16.IsCorrect = true;
            #endregion

            #region AddChoices
            choiceService.Add(c1);
            choiceService.Add(c2);
            choiceService.Add(c3);
            choiceService.Add(c4);
            choiceService.Add(c5);
            choiceService.Add(c6);
            choiceService.Add(c7);
            choiceService.Add(c8);
            choiceService.Add(c9);
            choiceService.Add(c10);
            choiceService.Add(c11);
            choiceService.Add(c12);
            choiceService.Add(c13);
            choiceService.Add(c14);
            choiceService.Add(c15);
            choiceService.Add(c16);
            #endregion

            return RedirectToAction("Exam", "Home");
        }

        public IActionResult Exam()
        {
            return View(examService.GetAllById(1));
        }

        [HttpPost]
        public IActionResult Delete(IFormCollection frm)
        {
            string str = frm["delete"].ToString();

            Exam exam = examService.GetByID(Convert.ToInt32(str));

            exam.IsActive = false;

            examService.Update(exam);

            return RedirectToAction("Exam", "Home");
        }

        [HttpPost]
        public IActionResult TakeExam(IFormCollection frm,int id)
        {
            string str = frm["take"].ToString();
            Exam exam = examService.GetByID(Convert.ToInt32(str));

            #region Questions2
            Question question = questionService.GetByExamID(exam.ExamID).FirstOrDefault();
            ViewData["question"] = question.QuestionText;
            Question question1 = questionService.GetByExamID(exam.ExamID).Skip(1).First();
            ViewData["question1"] = question1.QuestionText;
            Question question2 = questionService.GetByExamID(exam.ExamID).Skip(2).First();
            ViewData["question2"] = question2.QuestionText;
            Question question3 = questionService.GetByExamID(exam.ExamID).Skip(3).First();
            ViewData["question3"] = question3.QuestionText;
            #endregion

            #region ChoicesWithViewDatas
            Choice choice = choiceService.GetByQuestionID(question.QuestionID).FirstOrDefault();
            ViewData["choice"] = choice.ChoiceText;
            Choice choice1 = choiceService.GetByQuestionID(question.QuestionID).Skip(1).First();
            ViewData["choice1"] = choice1.ChoiceText;
            Choice choice2 = choiceService.GetByQuestionID(question.QuestionID).Skip(2).First();
            ViewData["choice2"] = choice2.ChoiceText;
            Choice choice3 = choiceService.GetByQuestionID(question.QuestionID).Skip(3).First();
            ViewData["choice3"] = choice3.ChoiceText;

            Choice choice4 = choiceService.GetByQuestionID(question1.QuestionID).FirstOrDefault();
            ViewData["choice4"] = choice4.ChoiceText;
            Choice choice5 = choiceService.GetByQuestionID(question1.QuestionID).Skip(1).First();
            ViewData["choice5"] = choice5.ChoiceText;
            Choice choice6 = choiceService.GetByQuestionID(question1.QuestionID).Skip(2).First();
            ViewData["choice6"] = choice6.ChoiceText;
            Choice choice7 = choiceService.GetByQuestionID(question1.QuestionID).Skip(3).First();
            ViewData["choice7"] = choice7.ChoiceText;

            Choice choice8 = choiceService.GetByQuestionID(question2.QuestionID).FirstOrDefault();
            ViewData["choice8"] = choice8.ChoiceText;
            Choice choice9 = choiceService.GetByQuestionID(question2.QuestionID).Skip(1).First();
            ViewData["choice9"] = choice9.ChoiceText;
            Choice choice10 = choiceService.GetByQuestionID(question2.QuestionID).Skip(2).First();
            ViewData["choice10"] = choice10.ChoiceText;
            Choice choice11 = choiceService.GetByQuestionID(question2.QuestionID).Skip(3).First();
            ViewData["choice11"] = choice11.ChoiceText;

            Choice choice12 = choiceService.GetByQuestionID(question3.QuestionID).FirstOrDefault();
            ViewData["choice12"] = choice12.ChoiceText;
            Choice choice13 = choiceService.GetByQuestionID(question3.QuestionID).Skip(1).First();
            ViewData["choice13"] = choice13.ChoiceText;
            Choice choice14 = choiceService.GetByQuestionID(question3.QuestionID).Skip(2).First();
            ViewData["choice14"] = choice14.ChoiceText;
            Choice choice15 = choiceService.GetByQuestionID(question3.QuestionID).Skip(3).First();
            ViewData["choice15"] = choice15.ChoiceText;
            #endregion

            return View(exam);
        }

        #region Ajax1
        public JsonResult CheckAnswer(string answer1, int examid)
        {
            Exam exam = examService.GetByID(examid);
            Question question = exam.Questions.FirstOrDefault();
            Choice choice = question.Choices.Where(a => a.IsCorrect == true).FirstOrDefault();
            if (answer1 == choice.ChoiceText)
            {
                return Json("OK");
            }
            else
                return Json("Error");
   
        }
        #endregion

        #region Ajax2
        public JsonResult CheckAnswer2(string answer2, int examid)
        {
            Exam exam = examService.GetByID(examid);
            Question question = questionService.GetByExamID(exam.ExamID).Skip(1).First();
            Choice choice = question.Choices.Where(a => a.IsCorrect == true).FirstOrDefault();
            if (answer2 == choice.ChoiceText)
            {
                return Json("OK");
            }
            else
                return Json("Error");

        }
        #endregion

        #region Ajax3
        public JsonResult CheckAnswer3(string answer3, int examid)
        {
            Exam exam = examService.GetByID(examid);
            Question question = questionService.GetByExamID(exam.ExamID).Skip(2).First();
            Choice choice = question.Choices.Where(a => a.IsCorrect == true).FirstOrDefault();
            if (answer3 == choice.ChoiceText)
            {
                return Json("OK");
            }
            else
                return Json("Error");

        }
        #endregion

        #region Ajax4
        public JsonResult CheckAnswer4(string answer4, int examid)
        {
            Exam exam = examService.GetByID(examid);
            Question question = questionService.GetByExamID(exam.ExamID).Skip(3).First();
            Choice choice = question.Choices.Where(a => a.IsCorrect == true).FirstOrDefault();
            if (answer4 == choice.ChoiceText)
            {
                return Json("OK");
            }
            else
                return Json("Error");

        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
