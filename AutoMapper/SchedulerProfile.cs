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
           // funzionale
           /*
           .ForMember(dest => dest.NomeStudente, opt => opt.MapFrom(src => src.))
           .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name)) // Personalizza se necessario
           .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
           .ForMember(dest => dest.indirizzo, opt => opt.MapFrom(src => src.Address))

           */
           ;
    //    .ForMember(dest => dest.Id_School, opt => opt.MapFrom(src => src.id));
    // Aggiungi altri mapping qui  
        }
    }
}

