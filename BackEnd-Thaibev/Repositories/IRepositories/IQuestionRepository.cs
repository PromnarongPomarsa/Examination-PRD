using BackEnd_Thaibev.Models;

namespace BackEnd_Thaibev.Repositories.IRepositories
{
    public interface IQuestionRepository
    {
        Task<ResponseDto> saveQuestion(TbTQuestion entity)
        Task<ResponseDto> deleteQuestion(TbTQuestion entity)
    }
}
