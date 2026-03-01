using AspNetCoreGeneratedDocument;
using BackEnd_Thaibev.Models;
using BackEnd_Thaibev.Models.Dto;
using BackEnd_Thaibev.Repository.IRepository;
using BackEnd_Thaibev.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Thaibev.Controllers
{
    [Route("api/quiz")]

    public class QuizController : Controller
    {
        private ResponseDto _response;
        private readonly IMasterRepository _masterRepo;
        private readonly IQuestionService _questionService;
        public QuizController(IMasterRepository masterRepo, IQuestionService questionService)
        {
            _response = new ResponseDto();
            _masterRepo = masterRepo;
            _questionService = questionService;
        }

        [HttpGet("get-all-msg")]
        public async Task<ResponseDto> getAllMsg()
        {
            ResponseDto response = await _masterRepo.getAllMsg();
            return _response = response;
        }

        [HttpPost("save-question")]
        public async Task<ResponseDto> saveQuestion([FromBody] TbTQuestionDto request)
        {
            ResponseDto response = await _questionService.createQuestion(request);
            return _response = response;
        }

        [HttpGet("get-question")]
        public async Task<ResponseDto> getQuestion()
        {
            ResponseDto response = await _questionService.getAllQuestion();
            return _response = response;
        }

        [HttpPost("delete-question")]
        public async Task<ResponseDto> deleteQuestion(int question_id)
        {
            ResponseDto response = await _questionService.deleteQuestion(question_id);
            return _response = response;

        }

    }
}
