using AutoMapper;
using EcdlBooking.Models;
using EcdlBooking.ViewModel;

namespace EcdlBooking.AutoMapper
{
    public class SchedulerProfile : Profile
    {
                 

    
public SchedulerProfile()
        {
            CreateMap<SchedulerEcdl, Admin_Scheduler_Index>()
            //Dati Dello Studente insscritto
           .ForMember(dest => dest.NomeStudente, opt => opt.MapFrom(src => src.Studente.Name))
           .ForMember(dest => dest.CognomeStudente, opt => opt.MapFrom(src => src.Studente.Surname))
           .ForMember(dest => dest.IdStudente, opt => opt.MapFrom(src => src.Studente.Id))
            //Dati del esame
           .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Exam.Data)) // Personalizza se necessario
           .ForMember(dest => dest.Ora, opt => opt.MapFrom(src => src.Exam.Ora))
           .ForMember(dest => dest.Luogo, opt => opt.MapFrom(src => src.Exam.School.Name))
           .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(src => src.Exam.School.id))

           // voto e data della prenotazione 

           ;
    //    .ForMember(dest => dest.Id_School, opt => opt.MapFrom(src => src.id));
    // Aggiungi altri mapping qui  
        }
    }
}

/*
 
        [Display(Name = "Codice Esame ")]
        public Guid id { get; set; }

        
        *public string NomeStudente { get; set; }

        
        *public String CpgnomeStudente { get; set; }

        
        *public DateTime Data { get; set; } // Data del Esame

        [Display(Name = "Ora del esame")]
        public DateTime Ora { get; set; } // ora Del Esame

        [Display(Name = "Scuola")]
        public string Luogo { get; set; } // puo contenere solo valori Aperti Chiuso

        // Lista A Tendina Deglie Esami
        public String TipoEsame { get; set; }


        [Display(Name = "Tipo Esame")]
        public String LuogoEsame { get; set; }

        [Display(Name = "Voto")]
        public List<SelectListItem> MenuEsami { get; set; }
        public float Voto { get; set; }

*/