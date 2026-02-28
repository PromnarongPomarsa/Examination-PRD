using BackEnd_Thaibev.Models;
using BackEnd_Thaibev.Models.Dto;
using BackEnd_Thaibev.Repositories.IRepositories;
using BackEnd_Thaibev.Repository.IRepository;
using BackEnd_Thaibev.Services.IServices;

namespace BackEnd_Thaibev.Services
{
    public class QuestionService : IQuestionService
    {
        private ResponseDto _response;
        private readonly IQuestionRepository _questionRepo;
        public QuestionService(IQuestionRepository questionRepo)
        {
            _response = new ResponseDto();
            _questionRepo = questionRepo;
        }
        public async Task<ResponseDto> createQuestion(TbTQuestionDto questionDto)
        {   
            ResponseDto response = await _questionRepo.saveQuestion();
        }
    }
}
