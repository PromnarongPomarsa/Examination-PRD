using BackEnd_Thaibev.Data;
using BackEnd_Thaibev.Models;
using BackEnd_Thaibev.Models.Dto;
using BackEnd_Thaibev.Repositories.IRepositories;

namespace BackEnd_Thaibev.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private ResponseDto _response;
        private readonly AppDbContext _db;
        public QuestionRepository(AppDbContext db)
        {
            _response = new ResponseDto();
            _db = db;
        }

        public async Task<ResponseDto> saveQuestion(TbTQuestion entity)
        {
            try
            {
               await _db.tb_t_question.Add(entity);
               await _db.SaveChanges();
               _response.Result = entity;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message.ToString();
            }
            return Task.FromResult(_response);
        }
        public async Task<ResponseDto> deleteQuestion(TbTQuestion entity)
        {
            try
            {
               await _db.tb_t_question.Remove(entity);
               await _db.SaveChanges();
               _response.Result = entity;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message.ToString();
            }
            return Task.FromResult(_response);
        }
    }
}
