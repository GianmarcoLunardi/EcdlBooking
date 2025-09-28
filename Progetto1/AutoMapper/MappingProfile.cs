using AutoMapper;
using EcdlBooking.Models;
using EcdlBooking.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EcdlBooking.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<School, CreateClassSchool>()
                // funzionale
                .ForMember(dest => dest.Id_School, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name)) // Personalizza se necessario
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.indirizzo, opt => opt.MapFrom(src => src.Address))

                //    .ForMember(dest => dest.Id_School, opt => opt.MapFrom(src => src.id));
                // Aggiungi altri mapping qui            

                ;



            // Conversione dell oggetto utente per la 
            CreateMap<ApplicationUser, Admin_Users_User>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                 .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                 .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                 .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                 .ForMember(dest => dest.Born, opt => opt.MapFrom(src => src.Born))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.familyContactPerson, opt => opt.MapFrom(src => src.familyContactPerson))
                .ForMember(dest => dest.familyContactPerson_phone, opt => opt.MapFrom(src => src.familyContactPerson_phone))
                .ForMember(dest => dest.familyContactPerson_email, opt => opt.MapFrom(src => src.familyContactPerson_email))
                //caricamento del menu delle scuole
                .ForMember(dest => dest.IdSchool, opt => opt.MapFrom(src => src.IdSchool))
                // Caricamento Della Scuola Dentro Il dto
                .ForMember(dest => dest.School, opt => opt.MapFrom(src => src.School))



                //.ForMember(dest => dest.ListSchool ,  opt => opt.MapFrom(src => new List<SelectListItem>()))
                ;// Mancano in fondo i campi per i menu a tendina
                 // public Guid IdSchool { get; set; }

            //public List<SelectListItem> ListSchool { get; set; } = null;
            //      public School School
        }
    }
}
