using AspNetCoreGeneratedDocument;
using BackEnd_Thaibev.Models;
using BackEnd_Thaibev.Models.Dto;
using BackEnd_Thaibev.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("get-all-msg")]
        public async Task<ResponseDto> getAllMsg()
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

        [HttpPost("save-question")]
        public async Task<ResponseDto> saveQuestion([FromBody] TbTQuestionDto request)
        {
            try
            {

            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message.ToString();
            }
            return _response;
        }

        [HttpPost("get-question")]
        public async Task<ResponseDto> getQuestion()
        {
            try
            {

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message.ToString();
            }
            return _response;
        }

    }
}
