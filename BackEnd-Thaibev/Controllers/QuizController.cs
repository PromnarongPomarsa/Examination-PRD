using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEnd_Thaibev.Repository.IRepository;
using BackEnd_Thaibev.Models;
using AspNetCoreGeneratedDocument;

namespace BackEnd_Thaibev.Controllers
{
    [Route("api/quiz")]

    public class QuizController : Controller
    {
        private ResponseDto _response;
        private readonly IMasterRepository _masterRepo;
        public QuizController(IMasterRepository masterRepo)
        {
            _response = new ResponseDto();
            _masterRepo = masterRepo;
        }
        // GET: QuizController
        public ActionResult Index()
        {
            return View();
        }

        // GET: QuizController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QuizController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuizController/Create
        [HttpGet("get-all-msg")]
        public async Task<ResponseDto> getAllMsg(IFormCollection collection)
        {
            try
            {
                ResponseDto response = await _masterRepo.getAllMsg();
                _response = response;

            }
            catch
            {
                _response.IsSuccess = false;
                _response.Message = "Error while getting data";
            }
            return _response;
        }

        // GET: QuizController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuizController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: QuizController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuizController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
