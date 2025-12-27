using AutoMapper;
using EcdlBooking.Models;
using EcdlBooking.ViewModel;

namespace EcdlBooking.AutoMapper
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<Exam, Admin_Exam_Create>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.Ora, opt => opt.MapFrom(src => src.Ora))
                .ForMember(dest => dest.TipoSessione, opt => opt.MapFrom(src => src.TipoSessione))
                .ForMember(dest => dest.LuogoEsameId, opt => opt.MapFrom(src => src.IdSchool))
                .ForMember(dest => dest.EsaminatoreId, opt => opt.MapFrom(src => src.IdEsaminatore))
                ;

                CreateMap<Admin_Exam_Create, Exam>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.Ora, opt => opt.MapFrom(src => src.Ora))
                .ForMember(dest => dest.TipoSessione, opt => opt.MapFrom(src => src.TipoSessione))
                .ForMember(dest => dest.IdSchool, opt => opt.MapFrom(src => src.LuogoEsameId))
                .ForMember(dest => dest.IdEsaminatore, opt => opt.MapFrom(src => src.EsaminatoreId))
                 //facciamo attenzione alla proprietà di navigazione       
                
                ;

            /*
             *     public class Exam
                {
                    [Key]
                    xpublic Guid id {get; set;}
                    xpublic DateTime Data { get; set; }
                    xpublic DateTime Ora { get; set; } // ora Del Esame
                    public string TipoSessione { get; set; }

                    // Con questa relazione si indica in quale scuola si fa l esame in una scuola

                    [ForeignKey(nameof(School))]
                    public Guid IdSchool { get; set; }
                    public School School { get; set; }

                    //Relazione com L Esaminatore
                    // Un  esame viene fatto da un esaminatore
                    [ForeignKey(nameof(ApplicationUser))]
                    public Guid IdEsaminatore { get; set; } 
                    public ApplicationUser Esaminatore { get; set; }    


                }
             */
        }


    }
}
