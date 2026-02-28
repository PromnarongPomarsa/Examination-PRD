using BackEnd_Thaibev.Models;
using BackEnd_Thaibev.Models.Dto;

namespace BackEnd_Thaibev.Services.IServices
{
    public interface IQuestionService
    {
        Task<ResponseDto> getAllQuestion();
        Task<ResponseDto> createQuestion(TbTQuestionDto questionDto);
        Task<ResponseDto> deleteQuestion(int question_id);
    }
}
