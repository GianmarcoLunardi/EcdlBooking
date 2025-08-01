using AutoMapper;
using EcdlBooking.Models;
using EcdlBooking.ViewModel;

namespace EcdlBooking.AutoMapper
{
    public class UserProfile : Profile
    {
        public  UserProfile()
        {

            // Conversione dell oggetto utente per la 
            CreateMap<ApplicationUser, Admin_Users_User>()
                 .ReverseMap();

        }
    }
    
}
