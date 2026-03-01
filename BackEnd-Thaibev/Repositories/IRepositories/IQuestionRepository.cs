using BackEnd_Thaibev.Models;

namespace BackEnd_Thaibev.Repositories.IRepositories
{
    public interface IQuestionRepository
    {
        Task<ResponseDto> saveQuestion(TbTQuestion entity);
        Task<ResponseDto> saveChoiceList(List<TbTChoiceItems> entity);
        Task<ResponseDto> deleteQuestion(TbTQuestion entity);
        Task<ResponseDto> getQuestionAll();
        Task<ResponseDto> getQuestionById(int question_id);
        Task<ResponseDto> getChoiceItemsAll();
    }
}
