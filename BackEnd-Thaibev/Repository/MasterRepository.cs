using BackEnd_Thaibev.Models;
using BackEnd_Thaibev.Repository.IRepository;
using BackEnd_Thaibev.Data;
namespace BackEnd_Thaibev.Repository
{
    public class MasterRepository : IMasterRepository
    {
        private ResponseDto _response;
        private readonly IConfiguration _configuration;
        private readonly ILogger<MasterRepository> _logger;
        private readonly AppDbContext _db;

        public MasterRepository(IConfiguration configuration, ILogger<MasterRepository> logger, AppDbContext db)
        {
            _response = new ResponseDto();
            _configuration = configuration;
            _logger = logger;
            _db = db;
        }

        public async Task<ResponseDto> getAllMsg()
        {
            try
            {
                var listMsg = _db.tb_m_msg.ToList();
                _response.Result = listMsg;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

    }
}
