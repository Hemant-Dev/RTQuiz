using RTQuiz.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTQuiz.IServices
{
    public interface IQuizSeriesService 
    {
        Task<IEnumerable<GetQuizSeriesDTO>> GetAllQuizSeries();
        Task<GetQuizSeriesDTO> GetQuizSeriesById(int id);
        Task<GetQuizSeriesDTO> CreateQuizSeries(CreateQuizSeriesDTO createQuizSeriesDTO);
        Task<GetQuizSeriesDTO> UpdateQuizSeries(UpdateQuizSeriesDTO updateQuizSeriesDTO);
        Task<GetQuizSeriesDTO> DeleteQuizSeries(int id);
    }
}
