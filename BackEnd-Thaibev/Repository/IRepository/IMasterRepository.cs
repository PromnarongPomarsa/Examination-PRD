using BackEnd_Thaibev.Models;

namespace BackEnd_Thaibev.Repository.IRepository
{
    public interface IMasterRepository
    {
        Task<ResponseDto> getAllMsg();
    }
}
