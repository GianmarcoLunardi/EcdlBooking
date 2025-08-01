using AutoMapper;
using EcdlBooking.Models;
using EcdlBooking.ViewModel;

namespace EcdlBooking.AutoMapper
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<Exam, Admin_Exam_Create>().ReverseMap();
        }
    }
}
