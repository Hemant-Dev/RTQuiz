using RTQuiz.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.IServices
{
    public interface IUserAnswerService
    {
        Task<IEnumerable<GetUserAnswerDTO>> GetAll();
    }
}
