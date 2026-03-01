using AutoMapper;
using Azure.Core;
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
        private readonly IMapper _mapper;
        public QuestionService(IQuestionRepository questionRepo, IMapper mapper)
        {
            _response = new ResponseDto();
            _questionRepo = questionRepo;
            _mapper = mapper;
        }

        public async Task<ResponseDto> createQuestion(QuestionListDto request)
        {

            request.createDate = DateTime.UtcNow;
            TbTQuestion entity = _mapper.Map<TbTQuestion>(request);
            ResponseDto response = await _questionRepo.saveQuestion(entity);
            return _response;
        }
        public async Task<ResponseDto> getAllQuestion()
        {
            ResponseDto getAllQuestion = await _questionRepo.getQuestionAll();

            if (!getAllQuestion.IsSuccess)
            {
                _response.IsSuccess = false;
                _response.Message = "Unable to process: No question data found";
                return _response;
            }
            List<TbTQuestion> listQuestion = getAllQuestion.Result as List<TbTQuestion>;

            ResponseDto getChoiceItemsAll = await _questionRepo.getChoiceItemsAll();

            if (!getChoiceItemsAll.IsSuccess)
            {
                _response.IsSuccess = false;
                _response.Message = "Unable to process: No choice items data found";
                return _response;
            }
            List<TbTChoiceItems> listChoiceItems = getChoiceItemsAll.Result as List<TbTChoiceItems>;

            List<QuestionListDto> questionList = new List<QuestionListDto>();
            foreach (var item in listQuestion)
            {
                QuestionListDto obj = new QuestionListDto();
                obj.id = item.id;
                obj.question = item.question;
                obj.createDate = item.create_date;
                obj.choiceItems = listChoiceItems.Where(x => x.ref_question_id == item.id).Select(x => new TbTChoiceItemsDto
                {
                    id = x.id,
                    refQuestionId = x.ref_question_id,
                    choiceText = x.choice_text,
                    isCorrect = x.is_correct,
                    createDate = x.create_date
                }).ToList();
                questionList.Add(obj);
            }

            _response.Result = questionList;
            return _response;
        }
        public async Task<ResponseDto> getQuestionById(int question_id)
        {
            ResponseDto response = await _questionRepo.getQuestionById(question_id);

            if (!response.IsSuccess)
            {
                _response.IsSuccess = false;
                _response.Message = response.Message;
                return _response;
            }

            TbTQuestionDto dataDto = _mapper.Map<TbTQuestionDto>(response.Result as TbTQuestion);
            _response.Result = dataDto;

            return _response;
        }
        public async Task<ResponseDto> deleteQuestion(int question_id)
        {
            ResponseDto getData = await _questionRepo.getQuestionById(question_id);

            if (getData.Result == null)
            {
                _response.IsSuccess = false;
                _response.Message = $"Unable to process: This question {question_id} id is doen't exists";
                return _response;
            }

            TbTQuestion questionData = getData.Result as TbTQuestion;
            ResponseDto response = await _questionRepo.deleteQuestion(questionData);

            _response = response;
            return _response;
        }
    }
}
